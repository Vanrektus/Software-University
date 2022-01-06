function solve(numberOfSteps, footprintInMeters, speed) {
    let distanceInMeters = numberOfSteps * footprintInMeters;
    let distanceInKm = distanceInMeters / 1000;
    let timeInMinutes = (distanceInKm / speed) * 60;

    for (let i = 500; i < distanceInMeters; i += 500) {
        timeInMinutes++;
    }

    let hours;
    let minutes;
    let seconds;

    if (timeInMinutes >= 60) {
        hours = Math.floor(timeInMinutes / 60);
        minutes = timeInMinutes - hours * 60;
    }
    else {
        hours = 0;
        minutes = Math.floor(timeInMinutes);
    }

    seconds = Math.round((timeInMinutes - Math.floor(timeInMinutes)) * 60);

    console.log(`${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds}`);
}

solve(4000, 0.60, 5);
solve(2564, 0.70, 5.5);