const ctx = document.getElementById('line');

new Chart(ctx, {
    type: 'line',
    data: {
        labels: ['Jan', 'Feb', 'Mac', 'Apr', 'May', 'Jun'],
        datasets: [{
            label: 'Monthly Calorie Intake',
            data: [2000, 3000, 1500, 3550, 2200, 1750],
            borderWidth: 1
        }]
    },
    options: {
        scales: {
            y: {
                beginAtZero: true
            }
        }
    }
});