function attachEventsListeners() {
    let buttonElement = document.querySelector('#convert');
    let inputDistanceElement = document.querySelector('#inputDistance');
    let inputUnitsElement = document.querySelector('#inputUnits');
    let outputDistanceElement = document.querySelector('#outputDistance');
    let outputUnitsElement = document.querySelector('#outputUnits');

    const allConvertionPosibilities = {
        'km-km': x => x * 1,
        'km-m': x => x * 1000,
        'km-cm': x => x * 100000,
        'km-mm': x => x * 1000000,
        'km-mi': x => x * 0.62137119223,
        'km-yrd': x => x * 1093.6132983,
        'km-ft': x => x * 3280.839895,
        'km-in': x => x * 39370.0787,

        'm-km': x => x * 0.001,
        'm-m': x => x * 1,
        'm-cm': x => x * 100,
        'm-mm': x => x * 1000,
        'm-mi': x => x * 0.00062137119224,
        'm-yrd': x => x * 1.0936133,
        'm-ft': x => x * 3.280839895,
        'm-in': x => x * 39.3700787,

        'cm-km': x => x * 0.00001,
        'cm-m': x => x * 0.01,
        'cm-cm': x => x * 1,
        'cm-mm': x => x * 10,
        'cm-mi': x => x * 0.0000062137119224,
        'cm-yrd': x => x * 0.010936132983,
        'cm-ft': x => x * 0.03280839895,
        'cm-in': x => x * 0.3937007874,

        'mm-km': x => x * 0.000001,
        'mm-m': x => x * 0.001,
        'mm-cm': x => x * 0.1,
        'mm-mm': x => x * 1,
        'mm-mi': x => x * 0.000000621371192,
        'mm-yrd': x => x * 0.001093613298,
        'mm-ft': x => x * 0.003280839895,
        'mm-in': x => x * 0.03937007874,

        'mi-km': x => x * 1.609344,
        'mi-m': x => x * 1609.344,
        'mi-cm': x => x * 160934.4,
        'mi-mm': x => x * 1609344,
        'mi-mi': x => x * 1,
        'mi-yrd': x => x * 1760,
        'mi-ft': x => x * 5280,
        'mi-in': x => x * 63360,

        'yrd-km': x => x * 0.0009144,
        'yrd-m': x => x * 0.9144,
        'yrd-cm': x => x * 91.44,
        'yrd-mm': x => x * 914.4,
        'yrd-mi': x => x * 0.00056818181,
        'yrd-yrd': x => x * 1,
        'yrd-ft': x => x * 3,
        'yrd-in': x => x * 36,

        'ft-km': x => x * 0.0003048,
        'ft-m': x => x * 0.3048,
        'ft-cm': x => x * 30.48,
        'ft-mm': x => x * 304.8,
        'ft-mi': x => x * 0.00018939393,
        'ft-yrd': x => x * 0.3333333,
        'ft-ft': x => x * 1,
        'ft-in': x => x * 12,

        'in-km': x => x * 0.0000254,
        'in-m': x => x * 0.0254,
        'in-cm': x => x * 2.54,
        'in-mm': x => x * 25.4,
        'in-mi': x => x * 0.0000157828283,
        'in-yrd': x => x * 0.02777777777,
        'in-ft': x => x * 0.0833333,
        'in-in': x => x * 1,
    };

    buttonElement.addEventListener('click', () => {
        let fromValue = inputUnitsElement.options[inputUnitsElement.selectedIndex].value;
        let toValue = outputUnitsElement.options[outputUnitsElement.selectedIndex].value;
        let fromTo = `${fromValue}-${toValue}`;

        let distance = Number(inputDistanceElement.value);

        let result = allConvertionPosibilities[fromTo](distance);

        outputDistanceElement.value = result;
    });
}