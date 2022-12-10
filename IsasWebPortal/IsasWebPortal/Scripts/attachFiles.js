//function AttachDialog()

//    $(function () {
//        $('#attachfiles-dialog').dialog({
//            autoOpen: false,
//            width: 400,
//            resizable: false,
//            title: 'hi there',
//            modal: true,
//            open: function(event, ui) {
//                //Load the CreateAlbumPartial action which will return 
//                // the partial view _CreateAlbumPartial
//                $(this).load('@Url.Action("CreateAlbumPartial")');
//            },
//            buttons: {
//                "Close": function () {
//                    $(this).dialog("close");
//                }
//            }
//        });

//        //$('#my-button').click(function () {
//        //    $('#attachfiles-dialog').dialog('open');
//        //});
//    })};

//function performClick(elemId) {
//    var elem = document.getElementById(elemId);
//    if (elem && document.createEvent) {
//        var evt = document.createEvent("MouseEvents");
//        evt.initEvent("click", true, false);
//        elem.dispatchEvent(evt);
//    }
//}


    //Below code will clear cache
$.ajaxSetup({ cache: false });





$(document).ready(function () {
    //Below code will append a click event to the class openDialog
    //which we assigned to the anchor previously
    $(".openDialog2").on("click", function (e) {
        //Below code will prevent default action from occuring
        //when openDialog anchor is clicked
        e.preventDefault();
        //This is the actual implementation of the dailog
        $("<div></div>")//.width("800px")//.css("width","500 px")
        //To the div created for dialog we will add class named dialog
        //this is done so that we can refer to the dialog later
        //we will see this in a short while why it is important
        .addClass("dialog2")
        //add attribute add id attribute
        //note id attribute is assigned the same value as data-dialog-id
        //attribute in openDialog anchor
        .attr("id", $(this).attr("data-dialog-id2"))
        //below code appends this div to body
        .appendTo("body")
        //below code describes the attribute for the dialog
        .dialog({
            //below code assigns title to the dialog
            //here we use same title as data-dialog-title attribute
            //in openDialog anchor tag
            
            modal: true,
           
            //title: $(this).attr("data-dialog-title"),
            resizable: false,
            position: { my: "center", at: "center", of: window },
            
            
            
            
            //this will append code to close the dialog
            //and also put close cross(x) in dialog
            //we press ESC key in keyboard will also close dialog
            close: function () {


                var dpas = document.getElementById("fileattachment");
                var in1 = dpas.firstElementChild.value;

                jQuery.dialog_info = {
                    input1: in1,
                   // input2: in2
                }

                var value1 = jQuery.dialog_info.input1;

                if (value1 != "") {




                    var fileAttachmentName = "fileAttachment";
                    var fileNum;
                    var escape = 0;
                    var fileattdiv = document.getElementById('fileAttachmentsDiv');

                    for (fileNum = 1; fileNum <= 100 && escape == 0; fileNum++) {

                        if (!document.getElementById(fileAttachmentName + fileNum))
                        { escape = 1; }

                    }

                    fileNum--;



                    var Newdiv = document.createElement('div');
                    fileattdiv.appendChild(Newdiv);
                    Newdiv.id = fileAttachmentName + fileNum;
                    $("#" + fileAttachmentName + fileNum).html(value1 + "  ");


                }

                //var a = document.createElement("a");
                //a.id = 'RemoveThis';
                //var t = document.createTextNode("Remove");
                //a.appendChild(t);
                //a.setAttribute('href', "javascript:;");



                // document.body.appendChild(a);



                /////////////////////////////////

                if (document.getElementById(fileAttachmentName + fileNum)) {

                var a = $('<a />', {
                    'id': 'RemoveThis2' + fileAttachmentName + fileNum,
                    'name': 'RemoveThis',
                    'href': 'javascript:void(0)',
                    'text': 'Remove'
                }).on('click', function () {

                    // $(this).closest("div").remove();

                   
                    $("#" + fileAttachmentName + fileNum).remove(); //remove the file path
                    $(this).remove(); // remove the Remove button.

                    //Your code
                });

               

                    $("#" + fileAttachmentName + fileNum).append(a);
                }





                $(this).remove();

            },
                

            
            })
        //below code says take href from openDialog anchor
        //which is /Home/ContactUs and load it to the modal dialog
        .load(this.href);
        $("#emailDialog2").width("500");
        
    });

    
       
   

}



);

//var sx = document.getElementById("openDialogDiv");
//    sx.style.width= "900px";

        $.ajaxSetup({ cache: false });


//Below code will run the JQuery when document is ready.
$(document).ready(function () {
    //Below code will append a click event to the class openDialog
    //which we assigned to the anchor previously
    $(".openDialog").on("click", function (e) {
        //Below code will prevent default action from occuring
        //when openDialog anchor is clicked
        e.preventDefault();
        //This is the actual implementation of the dailog
        $("<div></div>")//.width("800px")//.css("width","500 px")
        //To the div created for dialog we will add class named dialog
        //this is done so that we can refer to the dialog later
        //we will see this in a short while why it is important
        .addClass("dialog")
        //add attribute add id attribute
        //note id attribute is assigned the same value as data-dialog-id
        //attribute in openDialog anchor
        .attr("id", $(this).attr("data-dialog-id"))
        //below code appends this div to body
        .appendTo("body")
        //below code describes the attribute for the dialog
        .dialog({
            //below code assigns title to the dialog
            //here we use same title as data-dialog-title attribute
            //in openDialog anchor tag
            
            modal: true,
           
            //title: $(this).attr("data-dialog-title"),
            resizable: false,
            position: { my: "center", at: "center", of: window },
            
            
            
            
            //this will append code to close the dialog
            //and also put close cross(x) in dialog
            //we press ESC key in keyboard will also close dialog
            close: function () {
               // var in1 = $('#selectedformtemplate').val();
                var dpas = document.getElementById("formTemplatesId");
                var in1 = dpas.options[dpas.selectedIndex].text
                var in2 = dpas.value;

                var emailcomlogid = document.getElementById("emailCommunicationLogId");
              


                // var in2 = $('#text2').val();
                jQuery.dialog_info = {
                    input1: in1,
                    input2: in2
                }
              
                var value1 = jQuery.dialog_info.input1;
                var value2 = jQuery.dialog_info.input2;
                // $("#testingit").html(value1 + "  ");

                var docAttachmentName = "docAttachment";
                var docNum;
                var escape = 0;
                var docattdiv = document.getElementById('documentAttachmentsDiv');

                for (docNum=1; docNum <= 100 && escape==0; docNum++) {

                    if (!document.getElementById(docAttachmentName + docNum))
                    { escape = 1;}

                }

                docNum--;
                

                  //  if (!(document.getElementById(docAttachmentName + docNum))) {

                    var Newdiv = document.createElement('div');
                    docattdiv.appendChild(Newdiv);
                    Newdiv.id = docAttachmentName + docNum;
                    $("#" + docAttachmentName + docNum).html(value1 + "  ");


                    

                    //var a = document.createElement("a");
                    //a.id = 'RemoveThis';
                    //var t = document.createTextNode("Remove");
                    //a.appendChild(t);
                    //a.setAttribute('href', "javascript:;");
                                        
                   

                    // document.body.appendChild(a);
                


                /////////////////////////////////


                    var a = $('<a />', {
                        'id': 'RemoveThis' + docAttachmentName + docNum,
                        'name': 'RemoveThis',
                        'href': 'javascript:void(0)',
                        'text': 'Remove'
                    }).on('click', function () {

                        // $(this).closest("div").remove();

                        $("#" + docAttachmentName + docNum + "HiddenTemplateId").remove(); //remove hidden template Id.
                        $("#" + docAttachmentName + docNum).remove(); //remove the template Name
                        $(this).remove(); // remove the Remove button.

                        //Your code
                    });










                //////////////////////



                    $("#" + docAttachmentName + docNum).append(a);
                  

                    //hidden tag containing TemplateId of selected template Doc.

                    var NewHiddendiv = document.createElement('div');
                    NewHiddendiv.style.visibility = 'hidden';
                    Newdiv.appendChild(NewHiddendiv);
                    NewHiddendiv.id = docAttachmentName + docNum + "HiddenTemplateId";
                    $("#" + docAttachmentName + docNum + "HiddenTemplateId").html(value2);

              //  }

                    $(this).remove()
                
            },
            //buttons: {


            //    "Lets submit": function () {


            //    }



            //}
            //below code defines that the dialog is modal dialog
            
           
           
            
            
            
            //width: 'auto'

            
        })
        //below code says take href from openDialog anchor
        //which is /Home/ContactUs and load it to the modal dialog
        .load(this.href);
        $("#emailDialog").width("500");
        
    });

    
       
   

}



);


////$(document).ready(
//    function RemoveDiv() {

//    //$('#RemoveThis').click(function () {

//        var ni = document.getElementById('myDiv');

//        //var numi = document.getElementById('theValue');

//        //var num = (document.getElementById('theValue').value - 1) + 2;

//        //numi.value = num;

//        //var newdiv = document.createElement('div');

//        //var divIdName = 'my' + num + 'Div';

//        //newdiv.setAttribute('id', divIdName);

//        //newdiv.innerHTML = 'Element Number ' + num + ' has been added! <a href=\'#\' onclick=\'removeElement(' + divIdName + ')\'>Remove the div "' + divIdName + '"</a>';

//        //ni.appendChild(newdiv);

//    //});

//}





$(document).ready(function () {
    $('#clickMe').click(function () {

        var value1 = jQuery.dialog_info.input1;
        var value2 = jQuery.dialog_info.input2;
        $("#testingit").html(value1);


    })
});



//$(document).ready(function (){

//    $('#Send').click(function (){
    
//        $.ajax({
        
//            type: "POST",
//            url: "/FormTemplates/getNumberOfAttributes/";
             
        
//    })
           
            






//});



//$(document).ready(function () {


function CreateURLsAndAddLinkstoDB(EmailCommunicationLogId) {





    //emailCommunicationLogId, formTemplatesId
    var emailcommlogid = EmailCommunicationLogId;//document.getElementById("Id").value;

    var docAttachmentName = "docAttachment";
    
    var escape = 1;
    var docNum = 1;
    var formlink = '';

  

    for (docNum = 1; docNum < 100 && escape != 15; docNum++) {

        if (!document.getElementById(docAttachmentName + docNum))
        { escape++; }
        else
        {
            escape = 1;
            var formTemplatesid = document.getElementById(docAttachmentName + docNum + "HiddenTemplateId").outerText;
            formlink = '';

       
            

     $.ajax({


        url: '/FormLinks/formLinksCreatePreliminaries/',

        async: false,

        type: 'POST',

        dataType: 'json',

        data: { emailCommunicationLogId: emailcommlogid, formTemplatesId: formTemplatesid, formLink: formlink, isPath: "False" },

        success: function (result) { /* alert("Form " + e + " has " + result + " attributes");*/ },

        error: function () { alert("Error"); }

    })


        }


    }

    var fileAttachmentName = "fileAttachment";
    escape = 1;
    var fileNum = 1;
    formlink = '';

    ////////////////////////save paths////////////
    for (fileNum = 1; fileNum < 100 && escape != 15; fileNum++) {

        if (!document.getElementById(fileAttachmentName + fileNum))
        { escape++; }
        else
        {
            escape = 1;
            var filepath = document.getElementById(fileAttachmentName + fileNum).outerText;
            var res = filepath.substr(0, filepath.indexOf(" Remove"));
            formlink = res;




            $.ajax({


                url: '/FormLinks/formLinksCreatePreliminaries/',

                async: false,

                type: 'POST',

                dataType: 'json',

                data: { emailCommunicationLogId: emailcommlogid, formTemplatesId: '0', formLink: formlink, isPath: "True" },

                success: function (result) { /* alert("Form " + e + " has " + result + " attributes");*/ },

                error: function () { alert("Error"); }

            })


        }


    }






   
   
}





function AddLinksToEmailbodyAndSendEmail(EmailCommunicationLogId)
{

    var error="";

    return $.ajax({


        url: '/EmailCommunicationLog/preliminaryBeforeSendingEmail/',
        async: false,
        type: 'POST',

        dataType: 'json',

        data: {
            emailcommunicationlogid: EmailCommunicationLogId, error: error
            
        },

        //success: function (result) {  alert(result); },
        success: function (response) {
            //        if (response != null && response.success) {
            //            alert(response);
            //} else {
            //            alert(response);
            //}

        },

        error: function (response) {
            //alert("error!");  // 
        }

    }).responseText



}


//$('#SendEmailThroughAjax').click(function (e) {
function SaveEmailtoDB() {

    //emailCommunicationLogId, formTemplatesId
    
    
    var body = document.getElementById("Body").innerText.replace("Body", "");  //THIS!
    var body = body.replace("\r\n", "");  //THIS!
    

    var EmailTemplatesId = document.getElementById("emailTemplatesId");
    var EmailTemplatesIdss = EmailTemplatesId.options[EmailTemplatesId.selectedIndex].value; //THIS!

    var AgreementTemplatesId = document.getElementById("agreementTemplatesId");
    var AgreementTemplatesIdss = AgreementTemplatesId.options[AgreementTemplatesId.selectedIndex].value; //THIS!

    var EmailVaultid = document.getElementById("emailvaultid").value; //THIS!!

    var DefaultEmailAddress = document.getElementById("defaultEmailAddress").value; //THIS!!

    var ID = document.getElementById("Id").value; //THIS!!

    var FromAddress = document.getElementById("fromAddress").value; //THIS!

    var TimeStamp = document.getElementById("timeStamp").value; //THIS! 

    var ClientCaseId = document.getElementById("clientCaseId").value; //THIS! 

    var ToAddress = document.getElementById("toAddress").value; //THIS! 

    
    
   

   return $.ajax({


        url: '/EmailCommunicationLog/EmailCommunicationLogCreate/',
        async: false,
        type: 'POST',
        
        dataType: 'json',

        data: {
        Id: ID, Body: body, clientCaseId: ClientCaseId, agreementTemplatesId: AgreementTemplatesIdss,
        emailTemplatesId: EmailTemplatesIdss, timeStamp: TimeStamp, toAddress: ToAddress, fromAddress: FromAddress,
        defaultEmailAddress: DefaultEmailAddress, emailvaultid: EmailVaultid
    },

        //success: function (result) {  alert(result); },
        success: function (response) {
    //        if (response != null && response.success) {
    //            alert(response);
    //} else {
    //            alert(response);
    //}

    },

        error: function (response) {
        //alert("error!");  // 
    }

    }).responseText

        

}



function DeleteEmailCommunicationLogEntry(e) {

    return $.ajax({


        url: '/EmailCommunicationLog/EmailCommunicationLogDelete/',
        async: false,
        type: 'POST',

        dataType: 'json',

        data: {
            Id: e
        },

    });


}



function DeleteFormLinksEntry(e) {

    return $.ajax({


        url: '/FormLinks/FormLinksDelete/',
        async: false,
        type: 'POST',

        dataType: 'json',

        data: {
            Id: e
        },

    });


}



$('#SendEmailThroughAjax').click(function (e) {


    var res = SaveEmailtoDB() //email added to DB

    if (res.indexOf("Success") > -1) { //if email successfully added to DB, extract emailcommlogid and add URLs to DB.
        var EmailCommunicationLogId = res.match(/\d+/)[0];

        CreateURLsAndAddLinkstoDB(EmailCommunicationLogId);

        var res2 = AddLinksToEmailbodyAndSendEmail(EmailCommunicationLogId);


        if (res2.indexOf("Success") > -1) {
            alert("Email Sent Successfully!");
        }
        else {
            alert("Email not sent try again later");

            //delete email communication log and formlink entries

            DeleteFormLinksEntry(EmailCommunicationLogId);
            DeleteEmailCommunicationLogEntry(EmailCommunicationLogId);
            




        }


    }




});