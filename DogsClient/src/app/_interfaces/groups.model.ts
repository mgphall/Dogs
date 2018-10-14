import { Breeds } from './breeds.model';

export interface Groups {
    groupdId: string;
    groupName: string;

    breeds?: Breeds[];
}
