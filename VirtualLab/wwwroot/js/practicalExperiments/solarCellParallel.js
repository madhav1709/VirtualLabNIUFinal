$(init);

var total = 0;
var sa = [];
var sb = [];

function init() {
    $('.img-svg').draggable({
        cursor: 'move',
        revert: true
    });

    $('.js-circuit-connection').droppable({
        accept: '.img-svg',
        hoverClass: 'hovered',
        drop: handleComponentDrop
    });
}

function handleComponentDrop(event, ui) {
    var draggable = ui.draggable;

    var str1 = draggable.attr('id');
    var str2 = $(this).attr('id');

    var s11 = str1.slice(1, 2);
    var s12 = str2.slice(1, 2);

    var s21 = str1.slice(2, 3);
    var s22 = str2.slice(0, 1);

    var s31 = str1.slice(0, 1);
    var s32 = str2.slice(2, 3);

    var s41 = str1.slice(3, 4);
    var s42 = str2.slice(3, 4);

    sa.push(s21);
    sb.push(s22);

    console.log(s41);
    console.log(s42);
    if (s11 == s12 && s41 == s42) {
        ui.draggable.addClass('correct');
        ui.draggable.draggable('disable');
        $(this).droppable('disable');
        ui.draggable.position({ of: $(this), my: 'left top', at: 'left top' });
        ui.draggable.draggable('option', 'revert', false);
        total++;
    }
}

function onBtnClick() {
    if (total == 10) {
        ftotal = 0;
        for (i in sa) {
            if (sa[i] == sb[i]) {
                ftotal++;
            }
        }
        if (ftotal == 10) {
            alert('Congratulations!');
            var form = document.getElementById('solarCellParallel');
            form.submit();
        } else {
            if (!alert('Please check the arrangement and try again!')) {
                window.location.reload();
            }
        }
    } else {
        alert('Please place all the components!');
    }
}

function handleDropEvent(event, ui) {
    var draggable = ui.draggable;
    alert(
        'The circuit with ID "' + draggable.attr('id') + '" was dropped onto me!'
    );
}
