const themeSwitch = document.getElementById('theme-switcher');

themeSwitch.addEventListener('change', () => {
  if (document.getElementById('themeBody').classList.contains('darkTheme')) {
    document.getElementById('themeBody').classList.replace('darkTheme', 'lightTheme');
    document.getElementById("shoppingIcon").src = "img/icon/shoppingIconLT.svg";
    if (document.getElementById("githubIcon")) {
      document.getElementById("githubIcon").src = "img/icon/githubIconLT.svg";
      // linkedinIcon1 == linkedinIcon2
      document.getElementById("linkedinIcon1").src = "img/icon/linkedinIconLT.svg";
      document.getElementById("linkedinIcon2").src = "img/icon/linkedinIconLT.svg";
    }
    if (document.getElementById("searchIcon")) {
      document.getElementById("searchIcon").src = "img/icon/searchIconLT.svg";
      document.getElementById("filterIcon").src = "img/icon/filterIconLT.svg";
    }
    if (document.getElementById("userIcon")) {
      document.getElementById("userIcon").src = "img/icon/userIconLT.svg";
      document.getElementById("shoppingIcon1").src = "img/icon/shoppingIconLT.svg"; 
    }
    if (document.getElementById("redactIcon")) {
      document.getElementById("redactIcon").src = "img/icon/pencilIconLT.svg";
    }
    if (document.getElementById("dateInput")) {
      document.getElementById('dateInput').classList.replace('dateInputDT', 'dateInputLT');
    }
  } else {
    document.getElementById('themeBody').classList.replace('lightTheme', 'darkTheme');
    document.getElementById("shoppingIcon").src = "img/icon/shoppingIconDT.svg";
    if (document.getElementById("githubIcon")) {
      document.getElementById("githubIcon").src = "img/icon/githubIconDT.svg";
      // linkedinIcon1 == linkedinIcon2
      document.getElementById("linkedinIcon1").src = "img/icon/linkedinIconDT.svg";
      document.getElementById("linkedinIcon2").src = "img/icon/linkedinIconDT.svg";
    }
    if (document.getElementById("searchIcon")) {
      document.getElementById("searchIcon").src = "img/icon/searchIconDT.svg";
      document.getElementById("filterIcon").src = "img/icon/filterIconDT.svg";
    }
    if (document.getElementById("userIcon")) {
      document.getElementById("userIcon").src = "img/icon/userIconDT.svg";
      document.getElementById("shoppingIcon1").src = "img/icon/shoppingIconDT.svg";
    }
    if (document.getElementById("redactIcon")) {
      document.getElementById("redactIcon").src = "img/icon/pencilIconDT.svg";
    }
    if (document.getElementById("dateInput")) {
      document.getElementById('dateInput').classList.replace('dateInputLT', 'dateInputDT');
    }
  }
});

function openFilterForm() {
  isDisplayBlock = document.getElementById("filterForm").style.display;

  if(isDisplayBlock=="block"){
    document.getElementById("filterForm").style.display = "none";
  } else {
    document.getElementById("filterForm").style.display = "block";
  }
}

function redactShow() {
  isDisplayBlock = document.getElementById("staticLogin").style.display;

  if(isDisplayBlock==""){
    document.getElementById("staticLogin").style.display = "none";
    document.getElementById("redactLogin").style.display = "block";

    document.getElementById("staticName").style.display = "none";
    document.getElementById("redactName").style.display = "block";

    document.getElementById("staticSurname").style.display = "none";
    document.getElementById("redactSurname").style.display = "block";

    document.getElementById("staticEmail").style.display = "none";
    document.getElementById("redactEmail").style.display = "block";

    document.getElementById("staticPhone").style.display = "none";
    document.getElementById("redactPhone").style.display = "block";

    document.getElementById("redactSave").style.display = "block";
    if (document.getElementById('themeBody').classList.contains('darkTheme')) {
      document.getElementById("redactIcon").src = "img/icon/crossIconDT.svg";
    } else {
      document.getElementById("redactIcon").src = "img/icon/crossIconLT.svg";
    }
  } else {
    if(isDisplayBlock=="block"){
      document.getElementById("staticLogin").style.display = "none";
      document.getElementById("redactLogin").style.display = "block";
  
      document.getElementById("staticName").style.display = "none";
      document.getElementById("redactName").style.display = "block";
  
      document.getElementById("staticSurname").style.display = "none";
      document.getElementById("redactSurname").style.display = "block";
  
      document.getElementById("staticEmail").style.display = "none";
      document.getElementById("redactEmail").style.display = "block";
  
      document.getElementById("staticPhone").style.display = "none";
      document.getElementById("redactPhone").style.display = "block";

      document.getElementById("redactSave").style.display = "block";
      if (document.getElementById('themeBody').classList.contains('darkTheme')) {
        document.getElementById("redactIcon").src = "img/icon/crossIconDT.svg";
      } else {
        document.getElementById("redactIcon").src = "img/icon/crossIconLT.svg";
      }
    } else {
      document.getElementById("staticLogin").style.display = "block";
      document.getElementById("redactLogin").style.display = "none";
      
      document.getElementById("staticName").style.display = "block";
      document.getElementById("redactName").style.display = "none";
  
      document.getElementById("staticSurname").style.display = "block";
      document.getElementById("redactSurname").style.display = "none";
  
      document.getElementById("staticEmail").style.display = "block";
      document.getElementById("redactEmail").style.display = "none";
  
      document.getElementById("staticPhone").style.display = "block";
      document.getElementById("redactPhone").style.display = "none";

      document.getElementById("redactSave").style.display = "none";
      if (document.getElementById('themeBody').classList.contains('darkTheme')) {
        document.getElementById("redactIcon").src = "img/icon/pencilIconDT.svg";
      } else {
        document.getElementById("redactIcon").src = "img/icon/pencilIconLT.svg";
      }
    }
  }
}

var isCartEmpty = document.querySelectorAll(".product");

if (document.getElementById("cartPage__button")) {
  if (isCartEmpty.length == 0) {
    document.getElementById("emptyCart").style.display = "block";
    document.getElementById("cartPage__button").disabled = true;
  } else {
    document.getElementById("emptyCart").style.display = "none";
    document.getElementById("cartPage__button").disabled = false;
  }
}
/*does not work*/
/*
function bookActive(event) {
  document.getElementById("product").style.display = "none";
  document.getElementById("filterForm").style.display = "none";
  document.getElementById("emptyCart").style.display = "none";
  event.stopPropagation();
}
*/
if (document.getElementById("radioInput1")) {
  if (document.getElementById("radioInput1").checked = true) {
    document.getElementById("fictionalLiteratureSelect").disabled = false;
  } else {
    document.getElementById("fictionalLiteratureSelect").disabled = true;
  }
}