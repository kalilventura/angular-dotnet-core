import { Product } from './product.model';

export class Seller {
    sellerId?: number;
    name: string;
    telephone: string;
    commissionValue: number;
    sellerProducts: Product[];
}
