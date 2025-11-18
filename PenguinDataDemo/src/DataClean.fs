namespace PenguinData

open Deedle

module DataClean =

    let cleanData (df: Frame<int,string>) =
        printfn "\n Cleaning dataset..."
        printfn "→ Initial dataset: %d rows" df.RowCount

        // Step 1: Remove rows with completely missing measurements
        let df = 
            df
            |> Frame.filterRows (fun _ row ->
                let billLength = row.TryGetAs<float>("bill_length_mm")
                let billDepth = row.TryGetAs<float>("bill_depth_mm")
                let flipperLength = row.TryGetAs<float>("flipper_length_mm")
                let bodyMass = row.TryGetAs<float>("body_mass_g")
                
                // Keep rows that have at least 3 out of 4 measurements
                let validCount = 
                    [billLength.HasValue; billDepth.HasValue; 
                     flipperLength.HasValue; bodyMass.HasValue]
                    |> List.filter id
                    |> List.length
                validCount >= 3
            )

        printfn "→ After removing rows with too many missing values: %d rows" df.RowCount

        // Step 2: Handle missing sex data by replacing empty strings with "Unknown"
        let df =
            df
            |> Frame.mapCols (fun colName col ->
                if colName = "sex" then
                    col |> Series.mapValues (fun value ->
                        match value with
                        | null -> "Unknown" :> obj
                        | :? string as s when System.String.IsNullOrWhiteSpace(s) -> "Unknown" :> obj
                        | _ -> value
                    )
                else
                    col
            )

        // Step 3: Data validation - remove obvious outliers
        let df =
            df
            |> Frame.filterRows (fun _ row ->
                let billLength = row.TryGetAs<float>("bill_length_mm")
                let billDepth = row.TryGetAs<float>("bill_depth_mm")
                let flipperLength = row.TryGetAs<float>("flipper_length_mm")
                let bodyMass = row.TryGetAs<float>("body_mass_g")
                
                // Reasonable ranges for penguin measurements (in mm and grams)
                let isValidBillLength = not billLength.HasValue || (billLength.Value >= 30.0 && billLength.Value <= 60.0)
                let isValidBillDepth = not billDepth.HasValue || (billDepth.Value >= 10.0 && billDepth.Value <= 25.0)
                let isValidFlipperLength = not flipperLength.HasValue || (flipperLength.Value >= 170.0 && flipperLength.Value <= 240.0)
                let isValidBodyMass = not bodyMass.HasValue || (bodyMass.Value >= 2500.0 && bodyMass.Value <= 6500.0)
                
                isValidBillLength && isValidBillDepth && isValidFlipperLength && isValidBodyMass
            )

        printfn "→ After data validation: %d rows" df.RowCount

        // Step 4: Create derived features - bill area
        let billAreaSeries = 
            df?bill_length_mm * df?bill_depth_mm
            |> Series.mapValues (fun value -> value :> obj)

        df.AddColumn("bill_area_mm2", billAreaSeries) |> ignore

        printfn "→ Final cleaned dataset: %d rows" df.RowCount
        df