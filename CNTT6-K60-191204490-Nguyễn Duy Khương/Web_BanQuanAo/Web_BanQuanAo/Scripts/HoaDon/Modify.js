const { Button } = require("../../assets/client/bootstrap/js/bootstrap.bundle");

function GetAllTTHD(a) {
    var url = 'https://localhost:44364/api/TTHD/';
    if (a != null) url = 'https://localhost:44364/api/TTHD/?TenNguoiDung=' + a
    $.ajax({
        url: url,
        method: 'GET',
        contentType: 'json',
        dataType: 'json',
        error: function (response) {
        },
        success: function (reponse) {

            var len = reponse.length;
         
            let table = '';
            for (var i = 0; i < len; i++) {
                
                table = table + '<tr>';
                table = table + '<td>' + reponse[i].TenNguoiDung + '</td>';
                table = table + '<td>' + reponse[i].TenKH + '</td>';
                table = table + '<td>' + reponse[i].MaHD + '</td>';
                table = table + '<td>' + reponse[i].TenSP + '</td>';
                table = table + '<td><img src ="/Images/LayoutData/' + reponse[i].Anh + '" /></td>';

                table = table + '<td>' + reponse[i].SoLuong + '</td>';
                table = table + '<td>' + reponse[i].Gia + '</td>';
                table = table + '<td>' + reponse[i].NgayDat + '</td>';
                table = table + '<td>' + '<button type="button" class="btn btn-danger update-button" onclick="deleteHD(' +"'"+  reponse[i].MaHD +"'"+','+"'" + reponse[i].MaSP +"'"+');">' + "Hủy" + '</button>' + '</td>';
                table = table + '</tr>';
            }
            $('#allKH').html(table);

        },
        fail: function (response) {
        }
    });
}

function GetCustomersSum(a) {
    var url = 'https://localhost:44364/api/TTHD/GetCustomersSum/';
    if (a != null) url = 'https://localhost:44364/api/TTHD/GetCustomersSum/?TenNguoiDung=' + a
    $.ajax({
        url: url,
        method: 'GET',
        contentType: 'json',
        dataType: 'json',
        error: function (response) {
        },
        success: function (reponse) {

            var len = reponse.length;

            let table = '';
            for (var i = 0; i < len; i++) {

                table = table + '<tr>';
                table = table + '<td>' + reponse[i].MaKH + '</td>';
                table = table + '<td>' + reponse[i].TenKH + '</td>';
                table = table + '<td>' + reponse[i].TenNguoiDung + '</td>';
                table = table + '<td>' + reponse[i].SDT + '</td>';
                table = table + '<td>' + reponse[i].TongTien + '</td>';
                table = table + '</tr>';
            }
            $('#allKH').html(table);

        },
        fail: function (response) {
        }
    });
}



function GetCustomersSumTop(a) {
    var url = 'https://localhost:44364/api/TTHD/GetCustomersSumTop/?top=' + a;
    
    if (a.length == 0) url = 'https://localhost:44364/api/TTHD/GetCustomersSum/';
    
    $.ajax({
        url: url,
        method: 'GET',
        contentType: 'json',
        dataType: 'json',
        error: function (response) {
        },
        success: function (reponse) {

            var len = reponse.length;

            let table = '';
            for (var i = 0; i < len; i++) {

                table = table + '<tr>';
                table = table + '<td>' + reponse[i].MaKH + '</td>';
                table = table + '<td>' + reponse[i].TenKH + '</td>';
                table = table + '<td>' + reponse[i].TenNguoiDung + '</td>';
                table = table + '<td>' + reponse[i].SDT + '</td>';
                table = table + '<td>' + reponse[i].TongTien + '</td>';
                table = table + '</tr>';
            }
            $('#allKH').html(table);

        },
        fail: function (response) {
        }
    });
}
function deleteHD(MaHD, MaSP) {
    var url='https://localhost:44364/api/TTHD/DeleteCustomer?MaHD=' + MaHD + '&MaSP=' + MaSP
    $.ajax({
        url: url,
        method: 'DELETE',
        contentType: 'json',
        dataType: 'json',
        success: function (reponse) {
            console.log(reponse)
            if (reponse == false) {
                alert("Xoá không thành công!");
            }
            else {
                console.log(url);
                alert("Xoá thành công!");
                GetAllTTHD(); //Gọi đến hàm lấy dữ liệu lên bảng
            }
        }
    });
}

//lấy theo ngày
