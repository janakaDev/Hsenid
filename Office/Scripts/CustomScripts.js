var RegisterUser = function () {
        var data = $("#myForm").serialize();

        $.ajax({
            type: "post",
            url: "/Register/Create",
            data: data,
            success: function (response) {
                $("#success").show();
            },
            fail: function () {
                alert("not successful");
            }
        })
}

var LoginrUser = function () {
    debugger
    var data = $("#myForm").serialize();

    $.ajax({
        type: "post",
        url: "/Login/LoginUser",
        data: data,
        success: function (response) {
            alert("Added Successfully");
        },
        fail: function () {
            alert("not successful");
        }
    })
  
}


function AddData() {
    var x = $("#Name").val();
    $.ajax({
        type:"get",
        url: "/Employee/getDesignation?name="+x,
        contenType: "Application/Json,charset=utf-8",
        dataType: "Json",
        success:function(data)
        {
            $("#Designation").val(data);
        },
        fail: function () {
            alert("failed");
        }
        
    })
}

function AddData2()
{
    var xy = $("#Name").val();
    $.ajax({
        type: "get",
        url: "/Employee/GetTotalOtHours?namew=" + xy,
        contenType: "Application/Json",
        dataType: "Json",
        success: function (data) {
            $("#TotalOt").val(data);
        },
        fail: function () {
            alert("operat");
        }
    })
}


function AddOtHours() {
    var data = $("#ajaxForm").serialize();
    $.ajax({
        type: "post",
        url: "/Employee/AddOtHours",
        data: data,
        success: function (response) {
            $("#success").show();
        },
        fail: function () {
            alert("not successful");
        }
    })
}

function DeleteEmployee(Id)
{
    

    $.ajax({
        type: "get",
        url: "/Employee/DeleteEmployeeData?id=" + Id,
        success:function(response)
        {
            alert("deleted"+Id);
            location.reload();
       }
        
    });

}
