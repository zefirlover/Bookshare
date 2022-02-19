const themeSwitch = document.getElementById('theme-switcher');

themeSwitch.addEventListener('change', () => {
  if (document.getElementById('themeBody').classList.contains('darkTheme')) {
    document.getElementById('themeBody').classList.replace('darkTheme', 'lightTheme');
    document.getElementById("shoppingIcon").src = "img/icon/shoppingIconLT.svg";
    document.getElementById("githubIcon").src = "img/icon/githubIconLT.svg";
    // linkedinIcon1 == linkedinIcon2
    document.getElementById("linkedinIcon1").src = "img/icon/linkedinIconLT.svg";
    document.getElementById("linkedinIcon2").src = "img/icon/linkedinIconLT.svg";
    if (document.getElementById("searchIcon")) {
      document.getElementById("searchIcon").src = "img/icon/searchIconLT.svg";
      document.getElementById("filterIcon").src = "img/icon/filterIconLT.svg";
    }
    if (document.getElementById("userIcon")) {
      document.getElementById("userIcon").src = "img/icon/userIconLT.svg";
      document.getElementById("shoppingIcon1").src = "img/icon/shoppingIconLT.svg";
      document.getElementById("redactIcon").src = "img/icon/pencilIconLT.svg";
    }
  } else {
    document.getElementById('themeBody').classList.replace('lightTheme', 'darkTheme');
    document.getElementById("shoppingIcon").src = "img/icon/shoppingIconDT.svg";
    document.getElementById("githubIcon").src = "img/icon/githubIconDT.svg";
    document.getElementById("linkedinIcon1").src = "img/icon/linkedinIconDT.svg";
    document.getElementById("linkedinIcon2").src = "img/icon/linkedinIconDT.svg";
    if (document.getElementById("searchIcon")) {
      document.getElementById("searchIcon").src = "img/icon/searchIconDT.svg";
      document.getElementById("filterIcon").src = "img/icon/filterIconDT.svg";
    }
    if (document.getElementById("userIcon")) {
      document.getElementById("userIcon").src = "img/icon/userIconDT.svg";
      document.getElementById("shoppingIcon1").src = "img/icon/shoppingIconDT.svg";
      document.getElementById("redactIcon").src = "img/icon/pencilIconDT.svg";
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