namespace PenguinData

open Deedle
open Plotly.NET

module Visualization =

    let scatterFlipperVsMass (df: Frame<int,string>) =
        printfn "\n Creating scatter plot of Flipper Length vs Body Mass..."
        
        // Extract data from the frame
        let flipperData = df?flipper_length_mm |> Series.values |> Seq.map float
        let massData = df?body_mass_g |> Series.values |> Seq.map float
        
        Chart.Scatter(
            x = flipperData,
            y = massData,
            mode = StyleParam.Mode.Markers
        )
        |> Chart.withTitle "Flipper Length vs Body Mass"
        |> Chart.show

    let billLengthBoxplot (df: Frame<int,string>) =
        printfn "→ Showing boxplot..."
        
        // Extract data for boxplot - just the bill length values
        let billData = df?bill_length_mm |> Series.values |> Seq.map float
        
        Chart.BoxPlot(billData)
        |> Chart.withTitle "Bill Length Distribution"
        |> Chart.show

    let histBodyMass (df: Frame<int,string>) =
        printfn "→ Showing histogram..."
        
        // Extract data for histogram
        let massData = df?body_mass_g |> Series.values |> Seq.map float
        
        Chart.Histogram(massData)
        |> Chart.withTitle "Body Mass Distribution"
        |> Chart.show

    let scatterBillAreaVsMass (df: Frame<int,string>) =
        printfn "→ Showing bill area vs body mass scatter plot..."
        
        // Extract data for scatter plot
        let billAreaData = df?bill_area_mm2 |> Series.values |> Seq.map float
        let massData = df?body_mass_g |> Series.values |> Seq.map float
        
        Chart.Scatter(
            x = billAreaData,
            y = massData,
            mode = StyleParam.Mode.Markers
        )
        |> Chart.withTitle "Bill Area vs Body Mass"
        |> Chart.show