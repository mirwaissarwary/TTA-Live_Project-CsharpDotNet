//FUNCTIONS FOR CREATE
function showRental() {
    /*alert("showRental function hit");*/
    $(".rental-create--rentalequipmentformcomponent").hide();     //$ = select("element" or ".classname" or "#idname")  .hide() = built in function to hide selected($) element
    $(".rental-create--rentalroomformcomponent").hide();
}

function showRentalEquipment() {
    /*alert("showRentalEquipment function hit");*/   //test alerts to display when functions are hit
    $(".rental-create--rentalroomformcomponent").hide();
    $(".rental-create--rentalequipmentformcomponent").show();
    
}

function showRentalRoom() {
    /*alert("showRentalRoom function hit");*/
    $(".rental-create--rentalequipmentformcomponent").hide();
    $(".rental-create--rentalroomformcomponent").show();
}


//Functions to change h4 at top of Form to match selected dropdown item
function changeRentalHeading1() {
    /*alert("changeRentalHeading hit");*/
    var location = document.getElementById("rental-create--formheading");
    location.innerHTML = "Rental";
   /* document.getElementsByIdName("rental-create--formheading").innerHTML = rentalHeading;*  <--OLD WAY DOESNT WORK*/
}

function changeRentalHeading2() {
    var location = document.getElementById("rental-create--formheading");
    location.innerHTML = "Rental Equipment";
}

function changeRentalHeading3() {
    var location = document.getElementById("rental-create--formheading");
    location.innerHTML = "Rental Room";
}



//FUNCTIONS FOR EDIT
function showRentalEdit() {
    $(".rental-edit--rentalequipmentformcomponent").hide();     //$ = select("element" or ".classname" or "#idname")  .hide() = built in function to hide selected($) element
    $(".rental-edit--rentalroomformcomponent").hide();
}

function showRentalEquipmentEdit() {
    $(".rental-edit--rentalroomformcomponent").hide();
    $(".rental-edit--rentalequipmentformcomponent").show();

}

function showRentalRoomEdit() {
    $(".rental-edit--rentalequipmentformcomponent").hide();
    $(".rental-edit--rentalroomformcomponent").show();
}



//Functions to change h4 at top of Form to match selected dropdown item
function changeRentalHeading1Edit() {
    /*alert("changeRentalHeading hit");*/
    var location = document.getElementById("rental-edit--formheading");
    location.innerHTML = "Rental";
    /* document.getElementsByIdName("rental-create--formheading").innerHTML = rentalHeading;*  <--OLD WAY DOESNT WORK*/
}

function changeRentalHeading2Edit() {
    var location = document.getElementById("rental-edit--formheading");
    location.innerHTML = "Rental Equipment";
}

function changeRentalHeading3Edit() {
    var location = document.getElementById("rental-edit--formheading");
    location.innerHTML = "Rental Room";
}

// Change display of Current and Expired Rental Request Cards
function RentRequestCurrentExpire() {
    // Change the name of the button
    var btnName = document.getElementById("rentReqToggleBtn").textContent.trim();
    if (btnName === "Expired rentals") {
        document.getElementById("rentReqToggleBtn").textContent = "Current rentals";
    } else {
        document.getElementById("rentReqToggleBtn").textContent="Expired rentals";      
    }

    // Toggle the cards from hidden to show and vis versa
    $(".RRCurrentCard").toggle();
    $(".RRExpiredCard").toggle();
}

