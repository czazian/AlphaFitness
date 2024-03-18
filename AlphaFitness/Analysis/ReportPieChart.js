const ctx2 = document.getElementById('pie');

new Chart(ctx2, {
    type: 'pie',
    data: {
        labels: ['Heart', 'Water', 'Calories', 'Exercise', 'Carbo'],
        datasets: [{
            label: 'Total Intake',
            data: [140, 543, 358, 654, 439],
            borderWidth: 1
        }]
    },
});