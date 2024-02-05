import { Button, Modal } from 'flowbite-react';
import { InterestTypeResponse, UpdateInterestRequest } from '../../services/openapi';
import { useContext, useEffect, useState } from 'react';
import { Label, TextInput, Select } from 'flowbite-react';
import { InterestControllContext } from '../context/InterestControllContext';

interface EditInterestProps {
    interestId: string;
}

export default function EditInterestModal(props: EditInterestProps){
    const [showModal, setShowModal] = useState<boolean>(false);
    const [typeIndex, setTypeIndex] = useState<number>(-1);
    const [name, setName] = useState<string>("");
    const [typeList, setTypeList] = useState<InterestTypeResponse[] | undefined>(undefined);

    const InterestControll = useContext(InterestControllContext);

    useEffect(() => {
        InterestControll.typesOfInterests
        .then((response) => {
            setTypeList(response)

            const interest = InterestControll.interests.find(x => x.interestId == props.interestId)
            setName(interest!.name!)

            const typeIndex = response.findIndex(x => x.interestTypeId == interest!.interestType!.interestTypeId)
            setTypeIndex(typeIndex)
        })
        .catch((error) => setTypeList([]))
    }, []);

    const onClick = (event: React.MouseEvent<HTMLElement>) => {
        console.log(event.target);
        console.log(event.currentTarget);
        setShowModal(true);
      };

      const onClose = () => {
        setShowModal(false);
      };

      const onChange = (e: React.FormEvent<HTMLInputElement>) => {
        const newValue = e.currentTarget.value;
        setName(newValue);
      }

    const onSave = (event: React.MouseEvent<HTMLElement>) => {
        console.log(event.target);
        console.log(event.currentTarget);

        const newData : UpdateInterestRequest = {
            interestId: props.interestId,
            name: name,
            interestTypeId: typeList![typeIndex].interestTypeId
        }

        console.log("newData")
        console.log(newData)

        InterestControll.updateInterest(props.interestId, newData);

        setShowModal(false);
    };

    const onSelectType = (e: React.FormEvent<HTMLSelectElement>) => {
        const selectedIndex = Number(e.currentTarget.value);

        console.log("New walue")
        console.log(selectedIndex)

        setTypeIndex(selectedIndex)
      }

    return(
        <div>
            <Button onClick={onClick}>
                Edit
            </Button>
            <Modal
                show={showModal}
                onClose={onClose}
            >
                <Modal.Header>
                Edit interest
                </Modal.Header>
                <Modal.Body>
                <div className="flex max-w-md flex-col gap-4">
                    <div>
                        <div className="mb-2 block">
                            <Label htmlFor="small" value="Name" />
                        </div>
                        <TextInput id="small" type="text" value={name} sizing="sm"  onChange={onChange} />
                    </div>
                    <div className="max-w-md">
                        <div className="mb-2 block">
                            <Label htmlFor="types" value="Type" />
                        </div>
                        <Select id="types" value={typeIndex} onChange={onSelectType}>
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
                <Button onClick={onSave}>
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