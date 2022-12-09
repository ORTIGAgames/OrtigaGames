using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenScenesControler : MonoBehaviour
{
    public static int[,] characters = new int[6, 3] { { 24, 4, 5 }, { 24, 5, 4 }, { 26, 2, 4 }, { 30, 3, 7 }, { 20, 5, 4 }, { 20, 7, 2 } };
    public static int upgradePoint = 0;
    public static string[] names = new string[6] { "Declan", "Winnie", "G470", "Nass", "Norbert", "Caroline" };
    public static string[,] backgrounds = new string[3, 6] { 
        { "A mushroom mercenary that comes from a wooded planet. Mercenaries of his species are highly requested by captains due to the different powers of its spores. They usually work with the highest bidder, but Declan got attracted by the protagonist�s quirky crew and decided to join them just for curiosity, although the pay was minimal.He is well known for his sarcasm and blank facial expression, what may make him look unfriendly, yet he is kind and generous towards his companions, even if he can�t stand Norbert.",
            "Winnie always wanted to be a space explorer. She comes from a wealthy family, who provided her with whatever equipment she needed. For years, Winnie explored space as a tourist, without ever experiencing any real danger. Her passion had always been finding innermost places and help those in need along the way, always wearing fancy space outfits and a smile on her face. After a while, she realized that she should earn what she wanted without any help, so she used her experience to become an independent explorer. Her intentions were always pure and even if she is now ashamed of how she was, she never left behind the glitter and the matching outfits. Now she has Calamari by her side, a small and playful alien who she found on one of her solo missions.",
            "Robot built by Norberts mother to look after him and keep him company during her absence. Since Norbert always wanted a cat as he was a kid, but never had one because of his mother allergy, she built a robot with catlike features.G470 has never liked the life of criminals and all she wants is Norbert to be happy and have a good life. She was the one who ended up convincing Norbert to accept the protagonists offer to join his crew. She is the wiser and most responsible of the crew. If someone has a question, G470 is the person who has the answer. However, Winnie is allowed to make only 5 questions a day.",
            "He is an alien who was found abandoned in an alley by a man who used him for illegal fighting competitions. He refuses to show his face because he was told by this man that his appearance was grotesque and it made him want to vomit just for looking at him. Therefore, since he was a kid he wore masks and clothes that hid his whole body.The protagonist went to one of the championships looking for someone strong and tough and there he found him. The alien accepted, got himself into an abandoned space suit and joined the team with a new identity and a name he took  from the suit�s label, NASS.NASS represents the clich� of the giant with a heart of gold, he can be intimidating due to his proportions and his covered face, but you won't find a kinder and gentler creature in the whole universe.",
            "His parents were explorers who collected objects they found and sold them at market. They died in an explosion during one of their expeditions when Norbert was 15 years old, leaving him alone with his robot sister G470.Norbert tried to make a living doing what his parents did together with G470, but they just found junk. They started looting and stealing ship components, which served them to survive on the black market.In one of their loots, when they were ready to make off with everything, Norbert spotted a mushroom alien. He knew how valuable its spores are, so he acted without thinking. A few seconds later, he stood up tied to a pole and saw G470 near a  person who made them an offer: join their crew. As of today, Declan still does not approve that decision. Norbert is a very easy going and extroverted person, doesn�t have manners and gets bored easily.",
            "This amphibious creature may seem a little simple-minded, and indeed she is. Caroline was a red tank fish called Burbu, whose existence was based on swimming in circles and eating whatever fell from the surface of the water, until a scientist named Ghoti injected on it a series of serums to make it develop an anthropomorphic body and certain complex emotions. It lived in a tank in Ghoti�s basement until it was drained by the space team. The others wanted to free it into a lake on Earth, but Winnie insisted to keep it. Caroline soon endeared itself to the crew and proved to be helpful on the battlefield, handling heavy weapons with a remarkable accuracy. To this day, she can't speak and communicates with simple gestures, but she is Winnie�s favorite." }, 
        { "Mushroom-shaped head, slim body and 2.15 meters tall. Always carries a plant from his planet in his mouth, which he sometimes bites as a stress reliever.",
            "Young human girl, 1.66 meters in height. She wears colorful and space styled clothes, has violet eyes and long blonde hair.",
            "G470 is a robot with catlike features and is 1.4 meters tall. Her face is a screen that changes expressions formed with letters and signs according to her mood.",
            "Alien of unknown species hidden inside of a 2.63 meter tall space suit with a hole in the helmet, which he used to enter into the suit. It has a pocket on the front, where he keeps snacks, mostly candy, to offer to anyone who needs them.",
            "He is a sloppy and thin human male, 1.94 meters tall. He cuts his own hair, which is messy. He also has a scar on his nose and wears shabby clothes and a chain from his mother.",
            "A fish-like creature, 1.75 meters tall. Its hair is so long it can be dragged on the ground. It wears a diving suit." }, 
        { "Attack with poisonous spores or offer an extra turn to a partner of your choice ", 
            "Shoots with her laser gun or sends Calamari to heal an ally 1 health point each turn.", 
            "Attack with her claws or heal 1/5 of G470�s total life to an ally of your choice per turn.", 
            "He can use melee attack with his hands or he can take a defensive stance to increase his defense for a turn.", 
            "He shoots his dual pistols and can try a risky strategy that has a 50% chance of succeeding.",
            "Shoots with its bazooka and with its ability it overloads its weapon by sending a burster missile that spreads the damage over an area." } 
    }; //En orden, backgrounds, descripcion y estilo de combate
    public static int[,] enemies = new int[6, 3] { { 16, 6, 2 }, { 12, 8, 1 }, { 10, 7, 2 }, { 20, 5, 10 }, { 100, 10, 7 }, { 10, 8, 1 } };
    public static string[] namesEnemies = new string[6] { "M. Himenopio", "F. Himenopio", "Krandle", "Ixoda", "HARNCKXSHOR", "Minion" };
    public static string[,] backgroundsEnemies = new string[3, 6] { 
        { "The himenopios are alien species native to Declan's planet.",
            "The himenopios are alien species native to Declan's planet.",
            "The Krangles are creatures from another galaxy who travel around the universe to devour life from other planets. They have openings where their ribs are located, that could release dangerously toxic to other living beings, but if a Krangle breathes them they wont be affected. Thanks to the equipment they wear during battles they could breathe directly their own toxins and endure it.",
            "The Ixodas are small and fast parasites who live off anything inert they find. They open their body and stick it to the surface of an object feeding themselves and slowly disintegrating the object. Ixodas are one of the most hated parasites because they often infect spaceships and eat all their expensive components.In their tail they have a fake head which they raise to show a big fake mouth to scare possible threats. What seems like their tail at first sight is actually their real head.",
            "HARNCKXSHOR is an unknown creature who lives in an antique ruin, he built himself an exoskeleton with parts of the ruin. His real body is a sticky mass that can be turned to any desired form so he walks around using various legs formed with that mass. He could drop part of their mass to form another non-intelligent living being, his minions, which he controls as they are part of him.", 
            "This mischiveous creatures follow their leader and don't think a lot." }, 
        { "Insectoid creatures similar to orchid mantis from Earth.",
            "Insectoid creatures similar to orchid mantis from Earth.", 
            "Funky looking dudes with gas masks.",
            "Wormy threatening creatures in disguise ", 
            "Creepy looking boss.", 
            "Silly little guys." }, 
        { "The male variation figths with their big front legs in a close range combat style.",
            "The female variation has sticky useless front legs and figths throwing bulges that gry in their tail and explode like bombs. ",
            "They tend to move as groups and have a desesperate last attack that releases their toxins.",
            "They dont fight, they just run away.",
            "Immovable, It only thinks in creating minions.",
            "Fight until they die." } 
    };
    public static string[] levelDescription = new string[4] {
        "First level ever! The team is dropped in a woody area from the planet where Declan comes from. The Federation need the team to get rid of a highly aggresive group of Himenopios. To win you must kill them all while keeping your team safe. They are able to go through the trees.", 
        "Second phase. You must defend the east sector of the colonial city of Keus. Your objective is to keep the enemy in line for a number of turns until the power fields are activated. (in contruction)",
        "This level is located in a Federation spaceship infested with Ixodas. Your objective is to  eliminate all Ixodas before they escape and infest another spaceship. (in construction)",
        "The team was assigned to defeat a mysterious life form named HARNCKXSHOR that doesn�t let explorers enter an antique and culture rich ruin which were claimed as his home. You must defeat him to succeed but be aware of his minions, he will spawn new every three enemy's turns. (in construction)." }; //Lo que tu quieres ese es el orden de aparici�n
    public static string[] levelNames = new string[4] { "The Himenopio attack", "The invasion of Keus' deep", "The infested spaceship", "The final boss" };

    public static bool firstTime = true;
    public static bool firstStats = true;
}
