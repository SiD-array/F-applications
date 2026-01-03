namespace PenguinData

open Deedle
open Plotly.NET

module Visualization =

    let private savePlot (filename: string) chart =
        let path = $"plots/{filename}"
        Chart.saveHtml(path, OpenInBrowser = false) chart
        printfn "   Saved: %s" path

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
        |> Chart.withXAxisStyle "Flipper Length (mm)"
        |> Chart.withYAxisStyle "Body Mass (g)"
        |> savePlot "flipper_vs_mass.html"

    let billLengthBoxplot (df: Frame<int,string>) =
        printfn "→ Creating bill length boxplot..."
        
        // Extract data for boxplot - just the bill length values
        let billData = df?bill_length_mm |> Series.values |> Seq.map float
        
        Chart.BoxPlot(billData)
        |> Chart.withTitle "Bill Length Distribution"
        |> Chart.withYAxisStyle "Bill Length (mm)"
        |> savePlot "bill_length_boxplot.html"

    let histBodyMass (df: Frame<int,string>) =
        printfn "→ Creating body mass histogram..."
        
        // Extract data for histogram
        let massData = df?body_mass_g |> Series.values |> Seq.map float
        
        Chart.Histogram(massData)
        |> Chart.withTitle "Body Mass Distribution"
        |> Chart.withXAxisStyle "Body Mass (g)"
        |> Chart.withYAxisStyle "Frequency"
        |> savePlot "body_mass_histogram.html"

    let scatterBillAreaVsMass (df: Frame<int,string>) =
        printfn "→ Creating bill area vs body mass scatter plot..."
        
        // Extract data for scatter plot
        let billAreaData = df?bill_area_mm2 |> Series.values |> Seq.map float
        let massData = df?body_mass_g |> Series.values |> Seq.map float
        
        Chart.Scatter(
            x = billAreaData,
            y = massData,
            mode = StyleParam.Mode.Markers
        )
        |> Chart.withTitle "Bill Area vs Body Mass"
        |> Chart.withXAxisStyle "Bill Area (mm²)"
        |> Chart.withYAxisStyle "Body Mass (g)"
        |> savePlot "bill_area_vs_mass.html"