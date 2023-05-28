import { Post } from "./post.model";

export class User{
    id!: string;
    firstName?: string;
    lastName?: string;
    profilePicture?: string;
    description?: string;
    posts?: Post[];
}