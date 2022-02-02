const container = document.getElementById("container");
document.body.addEventListener('keydown', keyPress);

const player = {
    x: -1,
    y: -1
};

function initializeMap() {
    console.log(tileMap01);
    for (let col = 0; col < tileMap01.width; col++) {
        let gridrow = document.createElement("div");
        container.appendChild(gridrow).className = "gridRow";

        for (let row = 0; row < tileMap01.height; row++) {

            const block = document.createElement("div");
            gridrow.appendChild(block).className = "block";
            block.id = "x" + row + "y" + col;
            switch (tileMap01.mapGrid[row][col][0]) {
                case 'W':
                    block.classList.add(Tiles.Wall);
                    break;
                case 'G':
                    block.classList.add(Tiles.Goal);
                    block.classList.add(Entities.Goal);
                    break;
                case ' ':
                    block.classList.add(Tiles.Space);
                    break;
                case 'B':
                    block.classList.add(Entities.Block);
                    break;
                case 'P':
                    block.classList.add(Entities.Character);
                    player.x = row;
                    player.y = col;
                    break;
            }
        }
    }
}

function keyPress(e) {
    switch (e.key) {
        case 'ArrowUp':
            e.preventDefault();
            movePlayer(0, -1);
            break;

        case 'ArrowDown':
            e.preventDefault();
            movePlayer(0, 1);
            break;

        case 'ArrowLeft':
            e.preventDefault();
            movePlayer(-1, 0);
            break;

        case 'ArrowRight':
            e.preventDefault();
            movePlayer(1, 0);
            break;

        case 'r':
            e.preventDefault();
            location.reload();
            break;

        default:
            break;
    }
}

function didWeWin(goals) {
    let win = false;
    let count = 0;

    for (const item of goals) {
        const check = document.getElementById(item.id);
        if (check.classList.contains(Tiles.Goal)) {
            if (check.classList.contains(Entities.Block)) {
                count++;
            } else {
                win = false;
            }
        } else {
            win = false;
        }
    }

    if (count === goals.length) {
        win = true;
    }

    return win;
}

function checkBlock(element, closeBlock) {
    if (!element.classList.contains(Entities.Block)) {
        return;
    }
    if (!closeBlock.classList.contains(Tiles.Goal)) {
    } else {
        closeBlock.classList.add(Entities.BlockDone);
    }
    if (closeBlock.classList.contains(Entities.Block) || closeBlock.classList.contains(Tiles.Wall)) {
    } else {
        element.classList.remove(Entities.Block);
        closeBlock.classList.add(Entities.Block);
    }
}

function checkBlockDone(element) {
    if (element.classList.contains(Entities.BlockDone)) {
        if (!element.classList.contains(Entities.Block)) {
            element.classList.remove(Entities.BlockDone);
        }
    }
}

function movePlayer(x, y) {
    const newY = player.y + y, newX = player.x + x, targetX = newX + x, targetY = newY + y,
        goals = document.getElementsByClassName(Tiles.Goal),
        playerBlock = document.getElementById("x" + player.x + "y" + player.y),
        target = document.getElementById("x" + newX + "y" + newY),
        closeBlock = document.getElementById("x" + targetX + "y" + targetY);

    checkBlock(target, closeBlock);

    if (!target.classList.contains(Tiles.Wall)) if (target.classList.contains(Entities.Block)) {
        console.log("oof");
    } else {
        playerBlock.classList.remove(Entities.Character);
        target.classList.add(Entities.Character);
        player.x = newX;
        player.y = newY;
    } else {
        console.log("oof");
    }

    checkBlockDone(playerBlock);

    if (didWeWin(goals)) {
        setTimeout(function () {
            alert("yay, you won!");
            window.location.reload();
        }, 500);
    }

}

initializeMap();