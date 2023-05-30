import { Product } from "./product.model";
import { User } from "./user.model";

export interface Message {
    id: string;
    content: string;
    timestamp: Date;
    senderId: string;
    sender: User;
    receiverId: string;
    receiver: User;
    productId: string;
    product: Product;
  }
  