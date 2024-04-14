module Template

open Falco.Markup
open Falco.Htmx
open Falco.Markup.Elem

module A = Falco.Markup.Attr

let mainTemplate mainContent = 
    html [] [
        head  [] [
            title [] [Text.raw "brdo"]
            meta [A.charset "utf-8"]
            meta [A.name "viewport"; A.content "width=device-width, initial-scale=1"]
            meta [A.name "color-scheme"; A.content "light dark"]
            script [A.src "https://unpkg.com/htmx.org@1.9.11"] []

            link [A.rel "icon"; A.href "/favicon.png"]
            link [A.rel "stylesheet"; A.href "https://cdn.jsdelivr.net/npm/@picocss/pico@2/css/pico.classless.zinc.min.css"]
            link [A.rel "stylesheet"; A.href "https://cdnjs.cloudflare.com/ajax/libs/animate.css/4.1.1/animate.min.css"]
            link [A.rel "stylesheet"; A.href "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.5.2/css/all.min.css"]
        ]
        body [] [
            header [] [
                nav [Hx.boost true] [
                    ul [] [
                        li [] [a [A.href "/"] [strong [] [span [A.style "color:#c1208b;"] [Text.raw "&lambda;"]; Text.raw "brdo"]]]
                    ]
                    ul [] [
                        li [] [a [A.href "/about"] [Text.raw "About"]]
                        li [] [a [A.href "/posts"] [Text.raw "Posts"]]
                        li [] [a [A.href "/links"] [Text.raw "Links"]]
                    ]
                ]
            ] 
            main [A.id "content";A.style "max-width: 660px; min-height:calc(100vh - 200px) "] mainContent 
            footer [A.style "text-align:center"] [
                a [A.href "mailto:brodylittle011@gmail.com"] [i [A.style "padding:8px";A.class' "fa-solid fa-square-envelope"] []]
                strong [A.style "padding:8px"] [span [A.style "color:#c1208b;"] [Text.raw "&lambda;"]]
                a [A.href "https://github.com/bord-o"] [i [A.style "padding:8px"; A.class' "fa-brands fa-github"] []]
            ]
        ]
    ]

let postCard title image name order =
    let delay = $"{order*100}ms"
    article [
                A.class' "animate__animated animate__fadeInLeft"; A.style $"display: flex; align-items: center; animation-delay: {delay};";
                Hx.boost true
            ] [
        img [A.src image;A.style "max-width: 20%; margin-right: 8px; border-radius: 8px;"] 
        a [A.href $"/posts/{name}"] [b [A.style "max-width: 70%"] [Text.raw title]]
    ]


let homeContent = 
    [
        br []
        br []
        h4 [] [
            Text.raw "I'm Brody, a software developer specializing in .NET, functional programming, and language design."
        ]
        br []
        br []
        section [] [small [] [Text.raw "what i've been working on"]]
        hr []

        postCard "Building a Lambda Calculus Interpreter with .NET Interop" "/posts/dotnet square.jpg" "dotnet_interp" 1
        postCard "A RISCV Implementation of the Tiger Compiler" "/posts/tigerhead.jpg" "tiger_compiler" 2
        postCard "Modern Languages to Carry the Flame of Standard ML" "/posts/poly.jpg" "modern_sml" 3
        postCard "Text Prediction Using Gzip and K-Nearest Neighbors" "/posts/knn.png" "gzip_knn" 4


        br []
        br []
        section [] [small [] [Text.raw "some links"]]
        hr []
        a [A.href "https://keleshev.com/composable-error-handling-in-ocaml"] [Text.raw "Composable Error Handling in OCaml"]; br []
        a [A.href "https://www.falcoframework.com/"] [Text.raw "F# Falco"]; br []
        a [A.href "https://hypermedia.systems/book/contents/"] [Text.raw "hypermedia.systems"]; br []
        a [A.href "https://sergeytihon.com/fsharp-weekly/"] [Text.raw "Sergey Tihon's Blog"]; br []

    ]

let postsContent =
    div [] [
        section [] [
            h4 [] [Text.raw "What I've Been Up To"]
        ]
        hr []
        postCard "Building a Lambda Calculus Interpreter with .NET Interop" "/posts/dotnet square.jpg" "dotnet_interp" 1
        postCard "A RISCV Implementation of the Tiger Compiler" "/posts/tigerhead.jpg" "tiger_compiler" 2
        postCard "Modern Languages to Carry the Flame of Standard ML" "/posts/poly.jpg" "modern_sml" 3
        postCard "Text Prediction Using Gzip and K-Nearest Neighbors" "/posts/knn.png" "gzip_knn" 4
    ]
    
let linksContent = 
    div [] [
        section [] [
            h4 [] [Text.raw "Some links I've found interesting..."]
        ]
        hr []
        a [A.href "https://keleshev.com/composable-error-handling-in-ocaml"] [Text.raw "Composable Error Handling in OCaml"]; br []
        a [A.href "https://www.falcoframework.com/"] [Text.raw "F# Falco"]; br []
        a [A.href "https://hypermedia.systems/book/contents/"] [Text.raw "hypermedia.systems"]; br []
        a [A.href "https://sergeytihon.com/fsharp-weekly/"] [Text.raw "Sergey Tihon's Blog"]; br []
    ]

let aboutContent = 
    div [] [
        section [] [
            h4 [] [Text.raw "About"]
            p [] [Text.raw "I'm Brody Little, a software developer from Michigan. I'm currently working at Gainwell Technologies."]
        ]

        section [] [
            h4 [] [Text.raw "Timeline"]
            p [] [Text.raw "..."]
        ]
        section [] [
            h4 [] [Text.raw "CV"]
            p [] [Text.raw "..."]
        ]
    ]
    
