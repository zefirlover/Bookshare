import { Author } from "./author";
import { Library } from "./library";

export interface Book {
    id: number;
    name: string;
    photoPath?: string;
    authors: Author[];
    library: Library;
}