module ArabicToRoman

let convertToRoman arabic = 
    match arabic with
    | 0 -> ""
    | _ -> "I"