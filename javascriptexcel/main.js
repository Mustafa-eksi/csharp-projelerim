const excel = require('exceljs');
const workbook = new excel.Workbook();
const filename = 'excel.xlsx';
const sqlite = require("sqlite3").verbose();
var qr = require('qr-image');
const fs = require('fs');

const vt = new sqlite.Database('./data.db', sqlite.OPEN_READWRITE, (err) => {
    if(err) return console.error(err.message);
});
//const sql=`CREATE TABLE users (tcno,isim_soyisim,rol,sicilno,kartid)`;
//vt.run(sql);
function kartidOlustur() {
    var kartid = "05";
    for(var k = 1; k <= 5; k++) {
        var sayi = Math.floor(Math.random() * 10).toString();
        kartid += sayi;
    }
    return kartid;
}
var kisisayisi = 0;
var tekrarlisayi = 0;
var tekrarlilar = new Array();
var tekrarsil = false;

async function QueryYap(q, soru_isaretleri) {
    let a;
    vt.all(q, soru_isaretleri, (err, rows) => {
        if(err) return console.error(err.message);
        a = rows;
    })
    while(typeof a === "undefined") {
        await new Promise(reslove => setTimeout(reslove, 0.5));
    }
    return a;
}

workbook.xlsx.readFile(filename).then(async ()=>{
    const worksheet = workbook.getWorksheet('Sheet1');
    var hicgirmedimi = false;
    var tcknler = new Array(worksheet.rowCount-2);
    while(!hicgirmedimi) {
        hicgirmedimi = true;
        for(var i = 2; i <= worksheet.rowCount; i++) {
            const row = worksheet.getRow(i);
            if(row.getCell('A').value == null || row.getCell('B').value == null || row.getCell('C').value == null) {
                hicgirmedimi = false;
                worksheet.spliceRows(i, 1);
                continue;
            }
        }
    }
    console.log("Boşlar silindi.");
    for(let i = 2; i <= worksheet.rowCount; i++) {

        const row = worksheet.getRow(i);
        const tckn = row.getCell('A').value.toString();
        const adsoyad = row.getCell('B').value;
        
        let tcliler = await QueryYap("SELECT count(*) FROM users where tcno=?", [tckn]);
        if(tcliler[0]['count(*)'] == 0) {
            const d = new Date();
            let yil = d.getFullYear().toString();
            const rol_ham = row.getCell('C').value.toString();
            let rolluler = await QueryYap("SELECT count(*) FROM users where rol='"+rol_ham+"'", []);
            let rolsayi = rolluler[0]['count(*)']+1;
            let rol;
            switch(rol_ham) {
                case "Yazılımcı":{ rol = 'Yz'; break;}
                case "Yardımcı":{ rol = 'Yr'; break;}
                case "Boş işler müdürü":{rol = 'Bo'; break;}
                default: rol = 'Belirsiz';
            }
            let mevcutsayi = 1;
            let mevcutlar = await QueryYap("SELECT count(*) FROM users", []);
            mevcutsayi = mevcutlar[0]['count(*)']+1;
            let sicilno = yil.charAt(3) + rol + rolsayi + 'T' + mevcutsayi;
            let kartid = kartidOlustur();
            let aynimi = true;
            while(aynimi) {
                let kartidliler = await QueryYap("SELECT count(*) FROM users where kartid="+kartid, []);
                if(kartidliler[0]['count(*)'] == 0) {
                    aynimi = false;
                }else {
                    kartid = kartidOlustur();
                }
            }
            var qr_svg = qr.image(kartid, { type: 'png' });
            qr_svg.pipe(require('fs').createWriteStream("./qrlar/"+adsoyad+'.png'));

            //console.log("-> " + [tckn, adsoyad, rol_ham, sicilno, kartid].toString())
            sql2 = `INSERT INTO users (tcno,isim_soyisim,rol,sicilno,kartid) VALUES (?,?,?,?,?)`;
            vt.run(sql2, [tckn, adsoyad, rol_ham, sicilno, kartid], (err6) => {
                if(err6) return console.error(err6.message);
            })
            kisisayisi++;
        }else {
            tekrarlilar.push([tckn, adsoyad]);
        }
    }
}).catch((err)=> {
    console.error("Bilinmeyen bir hata oluştu. " + err);
}).finally(()=> {
    console.log("Tekrarlı kişiler: ");
    tekrarlilar.forEach((v)=>{
        console.log(v[0] + " tcknli " + v[1]);
    })
    fs.writeFile('tekrarlilar.txt', tekrarlilar.join("\n"), function (err) {
        if (err) return console.log(err);
        console.log('Hello World > helloworld.txt');
      });
    console.log("Bitti.");
})
