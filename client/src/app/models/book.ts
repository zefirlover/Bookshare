import { Author } from "./author";
import { Library } from "./library";

export interface Book {
    name: string;
    photoPath?: string;
    authors: Author[];
    library: Library;
}