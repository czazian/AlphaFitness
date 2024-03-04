const ctx4 = document.getElementById('heartRate');

const data2 = {
    labels: [
        'Swimming',
        'Drinking',
        'Sleeping',
        'Running',
        'Coding',
        'Cycling',
        'Reading'
    ],
    datasets: [{
        label: '26 Mac 2024 (Tues)',
        data: [126, 81, 79, 137, 94, 122, 77],
        fill: true,
        backgroundColor: 'rgba(255, 99, 132, 0.2)',
        borderColor: 'rgb(255, 99, 132)',
        pointBackgroundColor: 'rgb(255, 99, 132)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgb(255, 99, 132)'
    }, {
        label: '27 Mac 2024 (Wed)',
        data: [119, 91, 83, 146, 86, 133, 79],
        fill: true,
        backgroundColor: 'rgba(54, 162, 235, 0.2)',
        borderColor: 'rgb(54, 162, 235)',
        pointBackgroundColor: 'rgb(54, 162, 235)',
        pointBorderColor: '#fff',
        pointHoverBackgroundColor: '#fff',
        pointHoverBorderColor: 'rgb(54, 162, 235)'
    }]
};

new Chart(ctx4, {
    type: 'radar',
    data: data2,
    options: {
        elements: {
            line: {
                borderWidth: 3
            }
        }
    },
});