function ShowHideDataDiv() {
    
    //  var ddlPassport = document.getElementById('<%=ddlPassport.ClientID%>');
    //var ddlPassport = document.getElementById("formTypeId");

    var ddlPassport = @(Model.formTemplateId)
    
  

    var nofatt = SelectNumberofAllowedAttributes(ddlPassport.options[ddlPassport.selectedIndex].text);
    var NoOfAttr = parseInt(nofatt.match(/\d+/)[0]);

    //var textboxesToHide = 15 - NoOfAttr;
    // var e = document.getElementById("ddlPassport");
    // var strUser = e.options[e.selectedIndex].val;

   
    //  dvPassport.style.display =  == 'Agreement' ? "block" : "none";
    //dvPassport.style.visibility = ddlPassport.value == "1" ? "block" : "none";

    for (i = 1; i <= NoOfAttr; i++) {
        var dvPassport = document.getElementById("attribute" + i);
       // dvPassport.textContent = dvPassport.textContent;
        dvPassport.style.display = "block";
        

    }

    for (i = NoOfAttr+1; i <= 15; i++)
    {
        var dvPassport = document.getElementById("attribute" + i);
        //dvPassport.value = "";
        dvPassport.style.display = "none";
    }

  
   
   
    

    
    
}

//on page load, the attributes textboxes displayed are equal to default 
///value selected in formtype dropdown
$(document).ready(ShowHideDataDiv());





function SelectNumberofAllowedAttributes(e) {

   
    //var flag = confirm('You are about to delete Employee ID ' + employeeId + firstName + ' permanently. Are you sure you want to delete this record?');
 
   // if (flag) {

    return $.ajax({

        url: '/FormTemplates/getNumberOfAttributes/',
        async: false,

        type: 'POST',

        data: { formType: e },

        dataType: 'json',

        success: function (result) { /* alert("Form " + e + " has " + result + " attributes");*/ },

        error: function () { alert("Error"); }


      

    }).responseText;

  //  }

    
   // return false;

}


   

















