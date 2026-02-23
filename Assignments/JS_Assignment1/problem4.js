let signalColor = "yellow";

switch (signalColor) {

    case "red":
        console.log("Signal Color: Red");
        console.log("Instruction: Stop");
        break;

    case "yellow":
        console.log("Signal Color: Yellow");
        console.log("Instruction: Get Ready");
        break;

    case "green":
        console.log("Signal Color: Green");
        console.log("Instruction: Go");
        break;

    default:
        console.log("Invalid Signal Color!");
        console.log("Please enter red, yellow, or green.");
}