const excel = require('exceljs');
const workbook = new excel.Workbook();
const filename = 'excel.xlsx';
var qr = require('qr-image');

function kartidOlustur() {
    var kartid = "05";
    for(var k = 1; k <= 5; k++) {
        var sayi = Math.floor(Math.random() * 10).toString();
        kartid += sayi;
    }
    return kartid;
}
var kisisayisi = 0;
workbook.xlsx.readFile(filename).then(()=>{
    const worksheet = workbook.getWorksheet('Sheet1');
    var hicgirmedimi = false;
    while(!hicgirmedimi) {
        hicgirmedimi = true;
        for(var i = 2; i <= worksheet.rowCount; i++) {
            if(i == worksheet.rowCount) {
                worksheet.addRow(['']);
                worksheet.spliceRows(i, 1);
                break;
            }
            const row = worksheet.getRow(i);
            if(row.getCell('A').value == null || row.getCell('B').value == null || row.getCell('C').value == null) {
                hicgirmedimi = false;
                worksheet.spliceRows(i, 1);
            }
        }
    }
    console.log("Boşlar silindi.");
    for(var i = 2; i < worksheet.rowCount; i++) {
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
        var kartid;
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
        kisisayisi++;
        //console.log(worksheet.getCell('D'+i).value)
    }
}).catch((err)=> {
    console.error("Bilinmeyen bir hata oluştu.");
}).finally(()=> {
    console.log("Yazma işlemi başladı");
    workbook.xlsx.writeFile(filename).then(()=>{
        console.log("İşlem başarılı, programı kapatabilirsiniz. Şu kadar kişinin sicilnosu ve kartidsi üretildi: " + kisisayisi);
        var bos = 0;
        while(true) {
            bos++;
        }
        }).catch((E)=> {
            console.error("Excel dosyasını kapatınız.");
            var bos2 = 0;
            while(true) {
                bos2++;
            }
        });
})
