function solve() {
    const actions = (hero) => ({
        fight() {
            hero.stamina--;

            console.log(`${hero.name} slashes at the foe!`);
        },
        cast(spell) {
            hero.mana--;

            console.log(`${hero.name} cast ${spell}`);
        },
    });

    return {
        fighter(name) {
            const hero = {
                name,
                health: 100,
                stamina: 100,
            };

            return Object.assign(hero, actions(hero));
        },
        mage(name) {
            const hero = {
                name,
                health: 100,
                mana: 100,
            };

            return Object.assign(hero, actions(hero));
        },
    };
}

function solve2() {
    const canFight = (hero) => ({
        fight() {
            hero.stamina--;

            console.log(`${hero.name} slashes at the foe!`);
        },
    });

    const canCast = (hero) => ({
        cast(spell) {
            hero.mana--;

            console.log(`${hero.name} cast ${spell}`);
        },
    });

    const fighter = (name) => {
        const hero = {
            name,
            health: 100,
            stamina: 100,
        };

        return Object.assign(hero, canFight(hero));
    };

    const mage = (name) => {
        const hero = {
            name,
            health: 100,
            mana: 100,
        };

        return Object.assign(hero, canCast(hero));
    };

    return { mage, fighter };
}

let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball");
scorcher.cast("thunder");
scorcher.cast("light");

const fighter = create.fighter("Scorcher 2");
fighter.fight();

console.log(fighter.stamina);
console.log(scorcher.mana);

console.log("=========");

let create2 = solve2();
const scorcher2 = create.mage("Scorcher");
scorcher2.cast("fireball");
scorcher2.cast("thunder");
scorcher2.cast("light");

const fighter2 = create.fighter("Scorcher 2");
fighter2.fight();

console.log(fighter2.stamina);
console.log(scorcher2.mana);
