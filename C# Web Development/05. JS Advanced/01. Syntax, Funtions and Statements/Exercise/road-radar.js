function solve(driverSpeed, area) {
    let maxSpeed;
    let result;

    switch (area) {
        case 'motorway':
            maxSpeed = 130;
            break;

        case 'interstate':
            maxSpeed = 90;
            break;

        case 'city':
            maxSpeed = 50;
            break;

        case 'residential':
            maxSpeed = 20;
            break;

        default:
            break;
    }

    if (driverSpeed > maxSpeed) {
        let difference = driverSpeed - maxSpeed;

        if (difference <= 20) {
            result = `The speed is ${difference} km/h faster than the allowed speed of ${maxSpeed} - speeding`;
        }
        else if (difference <= 40) {
            result = `The speed is ${difference} km/h faster than the allowed speed of ${maxSpeed} - excessive speeding`;
        }
        else {
            result = `The speed is ${difference} km/h faster than the allowed speed of ${maxSpeed} - reckless driving`;
        }
    }
    else if (driverSpeed <= maxSpeed) {
        result = `Driving ${driverSpeed} km/h in a ${maxSpeed} zone`;
    }

    console.log(result);
}

solve(40, 'city');
solve(21, 'residential');
solve(120, 'interstate');
solve(200, 'motorway');