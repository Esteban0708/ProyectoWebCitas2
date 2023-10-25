document.getElementById('bookingForm').addEventListener('submit', function(event) {
    event.preventDefault(); // Prevener el envío del formulario

    const date = new Date(document.getElementById('appointmentDate').value);
    displayCalendar(date.getMonth(), date.getFullYear());
});

function displayCalendar(month, year) {
    let firstDay = (new Date(year, month)).getDay();

    // Días de cada mes (asumiendo que febrero tiene 28 días)
    let daysInMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

    let calendar = document.getElementById('calendar');
    calendar.innerHTML = ""; // Limpiar el calendario actual

    // Crear las celdas del calendario
    for (let day = 1; day <= daysInMonth[month]; day++) {
        let cell = document.createElement('div');
        cell.textContent = day;

        // Si el día coincide con la cita, marcarlo
        if (day === (new Date(document.getElementById('appointmentDate').value)).getDate()) {
            cell.classList.add('date-booked');
        }

        calendar.appendChild(cell);
    }
}

// Mostrar el calendario actual al cargar la página
const currentDate = new Date();
displayCalendar(currentDate.getMonth(), currentDate.getFullYear());
