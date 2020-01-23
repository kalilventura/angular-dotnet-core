import { EAddressType } from './eAddressType.enum';

export class Address {
    id?: number;
    street: string;
    number: string;
    complement: string;
    district: string;
    city: string;
    state: string;
    country: string;
    zipCode: string;
    addressType: EAddressType;
}
