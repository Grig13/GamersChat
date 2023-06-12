import { UserDTO } from "./UserDTO.model";
import { PostComments } from "./post-comments.model";

export class Post{
    id?: string;
    content!: string;
    userId!: string;
    user?: UserDTO;
    comments?: PostComments[];
}