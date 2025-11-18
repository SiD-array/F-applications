open PenguinData.DataLoad
open PenguinData.DataClean
open PenguinData.Visualization

[<EntryPoint>]
let main argv =
    
    let raw = loadPenguins "penguins.csv"
    let cleaned = cleanData raw

    scatterFlipperVsMass cleaned
    billLengthBoxplot cleaned
    histBodyMass cleaned
    scatterBillAreaVsMass cleaned

    0
