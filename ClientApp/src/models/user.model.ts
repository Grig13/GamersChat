import { Post } from "./post.model";
import { Product } from "./product.model";

export class User{
    id!: string;
    firstName?: string;
    lastName?: string;
    profilePicture?: string;
    description?: string;
    posts?: Post[];
    connectionId?: string;
    products?: Product[];
}