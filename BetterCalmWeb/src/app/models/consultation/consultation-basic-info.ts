import { PacientBasicInfo } from '../pacient/pacient-basic-info';

export interface ConsultationBasicInfo {
    problematicId: number;
    pacient: PacientBasicInfo;
}