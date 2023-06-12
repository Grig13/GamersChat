import { Message } from "./message.model";
import { Post } from "./post.model";
import { Product } from "./product.model";

export interface UserDTO {
  userId: string;
  email: string;
  profileImageUrl: string;
  firstName: string;
  lastName: string;
  age: number;
  city: string;
  messages?: Message[];
  posts?: Post[];
  products?: Product[];
}