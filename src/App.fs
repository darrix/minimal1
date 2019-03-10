module App

(**
 The famous Increment/Decrement ported from Elm.
 You can find more info about Emish architecture and samples at https://elmish.github.io/
*)

open Elmish
open Elmish.React
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser

let initcanvas() =
  let canvas = document.getElementById("canvas") :?> HTMLCanvasElement
  canvas.width <- 200.
  canvas.height <- 200.
  let ctx = canvas.getContext_2d()
  ctx.fillStyle <- !^"rgb(200,0,0)"
  ctx.fillRect (10., 10., 55., 50.)
  ctx.fillStyle <- !^"rgba(0, 0, 200, 0.5)"
  ctx.fillRect (30., 30., 55., 50.)
  ctx.fillStyle <- !^"rgba(0, 0, 100, 0.5)"
  ctx.fillRect (50., 50., 55., 50.)
  
initcanvas()


// MODEL

type Model = int

type Msg =
| Increment
| Decrement

let init() : Model = 0

// UPDATE

let update (msg:Msg) (model:Model) =
    match msg with
    | Increment -> model + 1
    | Decrement -> model - 1

// VIEW (rendered with React)

let view (model:Model) dispatch =

  div []
      [ button [ OnClick (fun _ -> dispatch Increment) ] [ str "+" ]
        div [] [ str (string model) ]
        button [ OnClick (fun _ -> dispatch Decrement) ] [ str "-" ] ]

// App
Program.mkSimple init update view
|> Program.withReact "elmish-app"
|> Program.withConsoleTrace
|> Program.run
