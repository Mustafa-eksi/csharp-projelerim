const excel = require('exceljs');
const workbook = new excel.Workbook();
const filename = 'excel.xlsx';
//const qrcode = require("qrcode.min.js");
var qr = require('qr-image');


function kartidOlustur() {
    var kartid = "05";
    for(var k = 1; k <= 5; k++) {
        var sayi = Math.floor(Math.random() * 10).toString();
        kartid += sayi;
    }
    return kartid;
}

workbook.xlsx.readFile(filename).then(()=>{
    const worksheet = workbook.getWorksheet('Sheet1');
    for(var i = 2; i <= worksheet.rowCount; i++) {
        const row = worksheet.getRow(i);
        if(row.getCell('D').value != null) {
            continue;
        }
        var yil = row.getCell('A').value.toString();
        const adsoyad = row.getCell('B').value;
        const rol_ham = row.getCell('C').value.toString();
        var rolsayi = 1;
        for(var j = 2; j < i; j++) {
            if(worksheet.getRow(j).getCell('C').value == rol_ham) {
                //console.log("i: " + i + ", " +worksheet.getRow(j).getCell('C').value)
                rolsayi++;
            }
        }
        var rol;
        if(rol_ham == 'Yazılımcı') {
            rol = 'Yz';
        }else if(rol_ham == 'Yardımcı') {
            rol = 'Yr'
        }
        
        var sicilno = yil.charAt(3) + rol + rolsayi + 'T' + (i-1);
        var kartid = '0572894';
        for(var k = 2; k <= worksheet.rowCount; k++) {
            const kartid1 = worksheet.getRow(k).getCell('E').value;
            if(kartid  == kartid1) {
                kartid = kartidOlustur();
            }
        }
        var qr_svg = qr.image(kartid, { type: 'png' });
        qr_svg.pipe(require('fs').createWriteStream("./qrlar/"+adsoyad+'.png'));
        
        //console.log(kartid);
        worksheet.getCell('D'+i).value = sicilno;
        worksheet.getCell('E'+i).value = kartid;
        console.log(worksheet.getCell('D'+i).value)
    }
}).finally(()=> {
    console.log("İşlem başladı");
    workbook.xlsx.writeFile(filename).then(()=>{
        console.log("İşlem başarılı");
        }).catch((E)=> {
            console.error("Excel dosyasını kapatınız.");
        });
})
