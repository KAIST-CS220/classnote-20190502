let func a b =
  let x = a + b
  x * x // some complicated logic
  // suppose there is a bug

let f a b =
  func a b |> printfn "%d"

let g a b =
  func a b |> printfn "%x"

[<AbstractClass >]
type Animal () =
  let mutable x = 0
  let mutable y = 0
  abstract Breathe: unit -> unit // Abstract method
  member __.Move dx dy = // Normal method
    x <- x + dx
    y <- y + dy

[<AbstractClass >]
type Mammal () =
  inherit Animal () // Inherit the functionalities of Animal
  abstract MakeSound: unit -> unit

type Cat () =
  inherit Mammal ()
  member __.Run () = printfn "cat runs!"
  override __.MakeSound () =
    printfn "meow"
  override __.Breathe () =
    printfn "cat breathes"

type Dog () =
  inherit Mammal ()
  member __.Run () = printfn "dogs run!"
  override __.MakeSound () =
    printfn "bow wow"
  override __.Breathe () =
    printfn "dog breathes"

let genericfunc a =
  [ a ]

let speak (m: Mammal) =
  m.MakeSound ()

[<EntryPoint>]
let main _ =
  let d = Dog ()
  let c = Cat ()
  let lstofanimals = [ d :> Animal; c :> Animal ]
  speak d
  speak c
  0 // return an integer exit code
