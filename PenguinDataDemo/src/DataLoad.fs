namespace PenguinData

open FSharp.Data
open Deedle

module DataLoad =

    let loadPenguins (path: string) =
        printfn "\n Loading dataset..."
        let df = Frame.ReadCsv(path, hasHeaders = true)
        printfn "Rows: %d, Columns: %d" df.RowCount df.ColumnCount
        df