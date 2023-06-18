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
  connectionId?: string;
  posts?: Post[];
  products?: Product[];
}