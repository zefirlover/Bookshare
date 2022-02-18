const themeSwitch = document.getElementById('theme-switcher');

themeSwitch.addEventListener('change', () => {
  if (document.getElementById('themeBody').classList.contains('darkTheme')) {
    document.getElementById('themeBody').classList.replace('darkTheme', 'lightTheme');
    document.getElementById("shoppingIcon").src = "img/icon/shoppingIconLT.svg";
    document.getElementById("searchIcon").src = "img/icon/searchIconLT.svg";
    document.getElementById("filterIcon").src = "img/icon/filterIconLT.svg";
    document.getElementById("githubIcon").src = "img/icon/githubIconLT.svg";
    // linkedinIcon1 == linkedinIcon2
    document.getElementById("linkedinIcon1").src = "img/icon/linkedinIconLT.svg";
    document.getElementById("linkedinIcon2").src = "img/icon/linkedinIconLT.svg";
  } else {
    document.getElementById('themeBody').classList.replace('lightTheme', 'darkTheme');
    document.getElementById("shoppingIcon").src = "img/icon/shoppingIconDT.svg";
    document.getElementById("searchIcon").src = "img/icon/searchIconDT.svg";
    document.getElementById("filterIcon").src = "img/icon/filterIconDT.svg";
    document.getElementById("githubIcon").src = "img/icon/githubIconDT.svg";
    document.getElementById("linkedinIcon1").src = "img/icon/linkedinIconDT.svg";
    document.getElementById("linkedinIcon2").src = "img/icon/linkedinIconDT.svg";
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