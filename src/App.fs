module App

open Elmish
open Elmish.React
open Fable.React.Props
open Fable.React.Standard
open Fable.React.Helpers

type Model = int

type Msg =
    | Increment
    | Decrement

let init () = 0

let update msg model =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1

let view model dispatch =
    div []
        [ button [ OnClick(fun _ -> dispatch Decrement) ] [ ofString "-" ]
          div [] [ ofString (sprintf "%A" model) ]
          button [ OnClick(fun _ -> dispatch Increment) ] [ ofString "+" ] ]

Program.mkSimple init update view
|> Program.withReactBatched "app"
|> Program.run
