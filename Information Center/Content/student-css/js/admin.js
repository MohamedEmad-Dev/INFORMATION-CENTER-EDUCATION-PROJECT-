var sidebar = document.getElementById("sidebar");
var toggleBtn = document.getElementById("nav-toggle");
var mainContent = document.getElementById("main-content");
var header = document.getElementById("header");
// var sidebar = document.getElementById("");

toggleBtn.addEventListener("click", function () {
  sidebar.classList.toggle("toggle-sidebar");
  mainContent.classList.toggle("main-togg");
  header.classList.toggle("header-togg");
});
