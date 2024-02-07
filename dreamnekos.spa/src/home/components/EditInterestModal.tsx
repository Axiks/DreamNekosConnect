import { Button, Modal } from 'flowbite-react';
import { InterestResponse, InterestTypeResponse, UpdateInterestRequest } from '../../services/openapi';
import { useContext, useEffect, useState } from 'react';
import { Label, TextInput, Select } from 'flowbite-react';
import { InterestControllContext } from '../context/InterestControllContext';

interface EditInterestProps {
    modalName: string;
    interestResponse: InterestResponse | null;
    onAction: (resonse: UpdateInterestRequest) => void;
    closeModal: () => void;
}

export default function EditInterestModal(props: EditInterestProps){
    const [typeList, setTypeList] = useState<InterestTypeResponse[] | undefined>(undefined);
    const [name, setName] = useState<string>(props.interestResponse?.name || "");
    const [typeIndex, setTypeIndex] = useState<number>(0);

    const InterestControll = useContext(InterestControllContext);

    useEffect(() => {
        InterestControll.typesOfInterests
        .then((response) => {
            setTypeList(response)

            if (props.interestResponse?.interestId != null){
                const typeIndex = response.findIndex(x => x.interestTypeId == props.interestResponse?.interestType?.interestTypeId)
                setTypeIndex(typeIndex)
            }
        })
        .catch((error) => setTypeList([]))
    }, []);

    const onClose = () => {
        props.closeModal()
    };

    const onChangeName = (e: React.FormEvent<HTMLInputElement>) => {
        const newValue = e.currentTarget.value;
        setName(newValue);
    }

    const onChangeType = (e: React.FormEvent<HTMLSelectElement>) => {
        const selectedIndex = Number(e.currentTarget.value)

        setTypeIndex(selectedIndex)
    }

    const onAction = (event: React.MouseEvent<HTMLElement>) => {
        console.log(event.target);
        console.log(event.currentTarget);

        const newData : UpdateInterestRequest = {
            name: name,
            interestTypeId: typeList![typeIndex].interestTypeId
        }

        console.log("newData")
        console.log(newData)

        props.onAction(newData)
        onClose();
    };

    return(
        <div>
            <Modal
                show={true}
                onClose={onClose}
            >
                <Modal.Header>
                    {props.modalName}
                </Modal.Header>
                <Modal.Body>
                <div className="flex max-w-md flex-col gap-4">
                    <div>
                        <div className="mb-2 block">
                            <Label htmlFor="small" value="Name" />
                        </div>
                        <TextInput id="small" type="text" value={name} sizing="sm"  onChange={onChangeName} />
                    </div>
                    <div className="max-w-md">
                        <div className="mb-2 block">
                            <Label htmlFor="types" value="Type" />
                        </div>
                        <Select id="types" value={typeIndex} onChange={onChangeType}>
                            {
                                typeList != undefined && typeList != null && (
                                    typeList.map((type, index) => <option key={index} value={index}>{type.name}</option>)
                                )
                            }
                        </Select>
                    </div>
                </div>
                </Modal.Body>
                <Modal.Footer>
                <Button onClick={onAction}>
                    Save
                </Button>
                <Button
                    color="gray"
                    onClick={onClose}
                >
                    Cancel
                </Button>
                </Modal.Footer>
            </Modal>
        </div>
    )
} 