import { UserDTO } from "./UserDTO.model";
import { Post } from "./post.model";

export class PostComments{
    id?: string;
    content!: string;
    postId!: string;
    post?: Post;
    userId!: string;
    user?: UserDTO;
}