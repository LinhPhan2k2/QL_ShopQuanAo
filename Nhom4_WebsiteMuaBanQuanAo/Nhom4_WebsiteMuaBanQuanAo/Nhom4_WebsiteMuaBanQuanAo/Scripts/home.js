const text = document.querySelector('.text');
const text1 = document.querySelector('.text1');
const text2 = document.querySelector('.text2');
const toggleBall = document.querySelector('.toggle-ball');
const items = document.querySelectorAll(
    ".container-common , .footer , .text-common p ,.footer_link , .toggle , .toggle-icon"
);


const letters = document.querySelectorAll('span');
for(let i = 0 ; i < letters.length; i++) {
    letters[i].addEventListener("mouseover" , function() {
        letters[i].classList.add('active');
    });
};

// hiện element chậm
window.addEventListener('scroll', function scrollAction(e) {});

const srl = ScrollReveal({
    distance: '60px',
    duration: 2500,
    delay: 400,
});

srl.reveal(`.menu , .logo` , {origin: "top"} , {delay: 600});

srl.reveal(`.home-content , .news-list-item , .header-film-content , .footer_content , .footer_logo , .footer_copy , .toggle , .toggle-icon ` , {origin: "top"} , {delay: 600});
srl.reveal(`.game-left , .esports-left` , {origin: "left"} , {delay: 600});
srl.reveal(`.game-right , .esports-right , .discover-content` , {origin: "right"} , {delay: 600});
srl.reveal(`.content-film , .home-button` , {origin: "bottom"} , {delay: 600});

toggleBall.addEventListener("click" , () => {
    items.forEach(item => {
        item.classList.toggle("active");
    });
    toggleBall.classList.toggle("active");
});