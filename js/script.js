const themeSwitch = document.getElementById('theme-switcher');

themeSwitch.addEventListener('change', () => {
  document.body.classList.toggle('lightTheme');
});