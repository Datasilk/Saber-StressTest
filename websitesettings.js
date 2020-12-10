(function () {
    $('.prepare-stress-test button').on('click', () => {
        S.ajax.post('StressTest/Prepare', {}, () => {
            $('.prepare-stress-test').addClass('hide');
            $('.run-stress-test').removeClass('hide');
            $('.delete-stress-test').removeClass('hide');
        })
    });

    $('.delete-stress-test button').on('click', () => {
        S.ajax.post('StressTest/Delete', {}, () => {
            $('.prepare-stress-test').removeClass('hide');
            $('.run-stress-test').addClass('hide');
            $('.delete-stress-test').addClass('hide');
        })
    });
})();