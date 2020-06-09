// Dropdown js
$('.dropdown-toggle').dropdown()
function doProjectCreate() {

    actionMethod = "POST"
    actionUrl = "/project/CreateProject"
    var formData = new FormData();
    for (var i = 0; i < $('#photoUpload').length; i++) {
        formData.append("myImage", $('#photoUpload')[0].files[i]);
    }
    formData.append("ProjectName", $('#ProjectName').val());
    formData.append("Description", $('#Description').val());
    formData.append("Goal", $('#Goal').val());
    formData.append("End", $('#End').val());
    formData.append("Amount",($('#Amount').val()));
    formData.append("Reward", $('#Reward').val());
    formData.append("ProjectCategory", $('#ProjectCategory').val());
    formData.append("ProjectCreatorId",localStorage.getItem("userId"));
    
    
 
    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data:formData,

        contentType: false,
        processData: false,
        success: function (data, textStatus, jQxhr) {
            //  $('#responseDiv').html("The update has been made successfully");
            alert("Project Created")
            window.open("/project/GetProjects?UserId=" + userId, "_self")

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }


    });
    //{
    //    userId = data["id"]

    //    window.open("/project/GetProjects?UserId=" + userId, "_self")
    //}

}

function doAddUser() {
    if ($('#FirstName').val() == "") {
        alert("fill FirstName");
        $('#FirstName').focus();
        return;
    }
    if ($('#LastName').val() == "") {
        alert("fill LastName");
        $('#LastName').focus();
        return;
    }
    if ($('#Email').val() == "") {
        alert("fill Email");
        $('#Email').focus();
        return;
    }

    actionMethod = "POST"
    actionUrl = "/user/CreateUser"
    sendData = {
        "FirstName": $('#FirstName').val(),
        "LastName": $('#LastName').val(),
        "Email": $('#Email').val(),
        "ProjectCreatorId": localStorage.getItem("userId")
        
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),

        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {


            userId = data["userId"]
            localStorage.setItem("userId", userId);
            alert('You have successfully registered');
            window.open("/project/GetProjects?UserId=" + userId, "_self")

        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });


}

    $('#loginButton').click(
        function () {

            actionMethod = "POST"
            actionUrl = "/user/LoginUser"
            sendData = {
                "Email": $('#Email').val()

            }
            $.ajax({
                url: actionUrl,
                dataType: 'json',
                type: actionMethod,
                data: JSON.stringify(sendData),

                contentType: 'application/json',
                processData: false,
                success: function (data, textStatus, jQxhr) {
                    if (data == null) {
                        $('#responseDiv').html("There is no such customer");
                    }
                    else {
                        userId = data["userId"]
                        localStorage.setItem("userId", userId);
                        window.open("/project/GetProjects?UserId=" + userId, "_self")
                    }

                },
                error: function (jqXhr, textStatus, errorThrown) {
                    console.log(errorThrown);
                }
            });

        })

            
function BuyFund(projectId,fundId) {

    actionMethod = "POST"
    actionUrl = "/user/BuyFund/"
    sendData = {
        //"ProjectId": projectId,
        //"Amount": $('#Amount').val(),
        //"Reward": $('#Reward').val(),
        "ProjectId": projectId,
        "FundId": fundId,
        "UserId": localStorage.getItem("userId"),
        
        
    }

    $.ajax({
        url: actionUrl,
        dataType: 'json',
        type: actionMethod,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,
        success: function (data, textStatus, jQxhr) {
            $('#responseDiv').html(JSON.stringify(data));

            alert('You have successfully added a pledge!')
            location.reload();
            //window.open("/Project/SingleProject?id=" + projectId, "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            console.log(errorThrown);
        }
    });
}


$('#dropdownList').on('change', function (event) {
    var form = $(event.target).parents('form');
    form.submit();
});





