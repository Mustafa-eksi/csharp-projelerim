const excel = require('exceljs');
const { exit } = require('process');
const workbook = new excel.Workbook();
const filename = 'excel.xlsx';
const sqlite = require("sqlite3").verbose();
var qr = require('qr-image');

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
workbook.xlsx.readFile(filename).then(()=>{
    const worksheet = workbook.getWorksheet('Sheet1');
    var hicgirmedimi = false;
    var tcknler = new Array(worksheet.rowCount-2);
    while(!hicgirmedimi) {
        hicgirmedimi = true;
        for(var i = 2; i <= worksheet.rowCount; i++) {
            /*if(i == worksheet.rowCount) {
                worksheet.addRow(['']);
                worksheet.spliceRows(i, 1);
                break;
            }*/
            const row = worksheet.getRow(i);
            if(row.getCell('A').value == null || row.getCell('B').value == null || row.getCell('C').value == null) {
                hicgirmedimi = false;
                worksheet.spliceRows(i, 1);
                continue;
            }
            /*if(tekrarsil) {
                const tckn = row.getCell('A').value.toString();
                if(tcknler.includes(tckn)) {
                    
                    const adsoyad = row.getCell('B').value;
                    console.error("TCKN tekrarı var.");
                    tekrarlilar.push([tckn, adsoyad]);
                    hicgirmedimi = false;
                    worksheet.spliceRows(i, 1);
                }else {
                    tcknler[i-2] = tckn;
                }*/
        }
    }
    console.log("Boşlar silindi.");
    for(var i = 2; i <= worksheet.rowCount; i++) {
        const row = worksheet.getRow(i);
        const tckn = row.getCell('A').value.toString();
        const adsoyad = row.getCell('B').value;
        if(!tekrarsil) {
            if(tcknler.includes(tckn)) {
                console.error("TCKN tekrarı var.");
                tekrarlilar.push([tckn, adsoyad]);
                tekrarlisayi++;
                continue;
            }else {
                tcknler[i-2] = tckn;
            }
        }
        if(row.getCell('D').value != null) {
            continue;
        }
        const d = new Date();
        var yil = d.getFullYear().toString();
        
        const rol_ham = row.getCell('C').value.toString();

        
        
        var rolsayi = 1;
        for(var j = 2; j < i; j++) {
            if(worksheet.getRow(j).getCell('C').value == rol_ham && worksheet.getRow(j).getCell('D').value != null) {
                rolsayi++;
            }
        }
        var rol;
        if(rol_ham == 'Yazılımcı') {
            rol = 'Yz';
        }else if(rol_ham == 'Yardımcı') {
            rol = 'Yr'
        }
        
        let sicilno = yil.charAt(3) + rol + rolsayi + 'T' + ((i-1)-tekrarlisayi);
        let kartid;
        for(var k = 2; k <= worksheet.rowCount; k++) {
            const kartid1 = worksheet.getRow(k).getCell('E').value;
            if(kartid  == kartid1) {
                kartid = kartidOlustur();
            }
        }
        var qr_svg = qr.image(kartid, { type: 'png' });
        qr_svg.pipe(require('fs').createWriteStream("./qrlar/"+adsoyad+'.png'));
        worksheet.getCell('D'+i).value = sicilno;
        worksheet.getCell('E'+i).value = kartid;
        
        sql4=`SELECT count(*) FROM users where tcno=?`;
        vt.all(sql4, [tckn], (err, rows) => {
            if(rows[0]['count(*)'] != 0) {
                console.log("Kişi zaten veritabanına kayıtlı.");
            }else {
                sql = `INSERT INTO users (tcno,isim_soyisim,rol,sicilno,kartid) VALUES (?,?,?,?,?)`;
                vt.run(sql, [tckn, adsoyad, rol_ham, sicilno, kartid], (err) => {
                    if(err) return console.error(err.message);
                })
            }
        })

        kisisayisi++;
    }
}).catch((err)=> {
    console.error("Bilinmeyen bir hata oluştu.");
}).finally(()=> {
    console.log("Yazma işlemi başladı");
    workbook.xlsx.writeFile(filename).then(()=>{
        console.log("İşlem başarılı, programı kapatabilirsiniz. Şu kadar kişinin sicilnosu ve kartidsi üretildi: " + kisisayisi);
        console.log("Tekrarlı kişiler: ");
        tekrarlilar.forEach((v)=>{
            //console.log(v[0] + " tcknli " + v[1]);
        })
        }).catch((E)=> {
            console.error("Excel dosyasını kapatınız.");
            var bos2 = 0;
            while(true) {
                bos2++;
            }
        });
})
