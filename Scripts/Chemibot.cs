namespace MarcosQuijada.Chemibot {

    public enum SubstanceName { None, Water, Lemon, BakingSoda, Sugar, PowderCoffe, coffeResidual, TeHerbs, Salt, Vinegar, Sand, Gravel, Cement, Rocks, Nails, Clay, Earth,
    Clips, Peanuts, Marbles, MetalNuts, CatsSand, GrayClay, Eggs, WheatFlour, Milk, Butter, 
   
    WaterLemon, WaterSugar, Lemonade, LemonadeFailed, 
   
    WaterBakingsoda, LemonBakingSoda, AncientMedicine, AncientMedicineFailed, 
   
    CoffeAndResidual, CoffeAndResidualFailed, CoffeSugarAndResidual, CoffeSugarAndResidualFailed, PowderCoffeSugar, Coffe, CoffeFailed, CoffeNoSugar, CoffeNoSugarFailed, 
   
    TeHerbsAndResidual, TeHerbsAndResidualFailed, TeHerbsSugarAndResidual,  TeHerbsSugarAndResidualFailed, TeHerbsSugar, Te, TeFailed, TeWithSugar, TeWithSugarFailed, 
    
    SandCement, SandGravel, CementGravel, SandCementGravel, FinishMortar, Mortar, FailedMortar, SandWater, GravelWater, SandGravelWater, 
   
    ClipsPeanutsSalt, ClipsPeanuts, ClipsSalt, PeanutsSalt, MarblesNutsCatsSand, MarblesNuts, MarblesCatsSand, NutsCatsSand, 
    
    EggsSugar, EggsFlour, EggsMilk, SugarFlour, SugarMilk, FlourMilk, EggsSugarFlour, EggsSugarMilk, EggsFlourMilk, SugarFlourMilk, CakeMix, Cake, CakeFailed, 
    
    PowderGelatine, GelatineMix, FailedGelatineMix, FailedGelatine, Gelatine,  
    
    PowderPudin, PudinMix, FailedPudinMix, FailedPudin, Pudin, 
    
    UnknowMix, TeResidual};

    public enum Direction {up, down, left, right};
    public enum ParticleType {Explosion = 0, DigitalExplosion = 1, PowerUp = 2, ShowPowerUp = 3, ShowEnemy = 4, IceExplosion = 5};
 
    public enum FacesType {Happy, Sad, Surprised, Confused, Angry, Ill, BigHappy};

    public enum StatusType {Walk, Run, Talk, Great, Wrong};

    public enum StylePath {BackToIni, ReturnWay};

    public enum StatusGame {Mixing, Separating, Exploring, Focusing, Talking};

    public enum Temperature {normal, cold, heat};

    public enum MissionStep {Talk, Mix, Separate};
    public enum SubsNeededType {IsMust, posibleCorrect, posibleWrong, halfWay, youfailed};
    public enum focusEnum {outside, inside, talking,tutorial};

}