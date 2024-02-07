import React, { useContext, useEffect, useState } from 'react';
import { Button, Table } from 'flowbite-react';
import { InterestTypeResponse, UpdateInterestTypeRequest } from '../../services/openapi';
import { InterestTypeControllContext } from '../context/InterestTypeControllContext';
import EditInterestTypeModal from './EditInterestTypeModal';

interface InterestTypeViewProps {
    InterestTypes: InterestTypeResponse[];
}

function InterestTypeView(props: InterestTypeViewProps){
    const [createModal, setCreateModal] = useState<JSX.Element>();
    const [editModal, setEditModal] = useState<JSX.Element>();

    const InterestTypeControll = useContext(InterestTypeControllContext);

    const onDelete = (interetstTypeId: string) => {
        InterestTypeControll.deleteInterestType(interetstTypeId);
    };

    const closeModal = () => {
        setCreateModal(<></>)
        setEditModal(<></>)
    }


    const onEditBtn = (interetstType: InterestTypeResponse) => {
        const onEditAction = (newData: UpdateInterestTypeRequest) => {    
            InterestTypeControll.updateInterestType(interetstType.interestTypeId!, newData)
        }

        var modal = <EditInterestTypeModal
            modalName='Edit type interest'
            interestTypeResponse={interetstType}
            closeModal={ closeModal }
            onAction={onEditAction}/>
        setEditModal(modal)
    }

    const onCreateBtn = () => {
        const onCreateAction = (newData: UpdateInterestTypeRequest) => {    
            InterestTypeControll.createInterestType(newData)
        }

        var modal = <EditInterestTypeModal
            modalName='Create type interest'
            interestTypeResponse={null}
            closeModal={ closeModal }
            onAction={onCreateAction}/>
        setCreateModal(modal)
    }

    return(
        <>
        <Button onClick={() => onCreateBtn()}>
            Create type
        </Button>
        { createModal }
        { editModal }
        <Table hoverable={true}>
            <Table.Head>
                <Table.HeadCell>
                Interest type name
                </Table.HeadCell>
                <Table.HeadCell>
                <span className="sr-only">
                    Edit
                </span>
                </Table.HeadCell>
                <Table.HeadCell>
                <span className="sr-only">
                    Delete
                </span>
                </Table.HeadCell>
            </Table.Head>
            <Table.Body className="divide-y">
            {   InterestTypeControll.interestTypes.map((interestType, index) => 
                <Table.Row key={index} className="bg-white dark:border-gray-700 dark:bg-gray-800">
                    <Table.Cell className="whitespace-nowrap font-medium text-gray-900 dark:text-white">
                        {interestType.name}
                    </Table.Cell>
                    <Table.Cell>
                    <Button onClick={() => onEditBtn(interestType)}>
                            Edit
                        </Button>
                    </Table.Cell>
                    <Table.Cell>
                        <Button onClick={() => onDelete(interestType.interestTypeId!)}>
                            Delete
                        </Button>
                    </Table.Cell>
                </Table.Row>
                )}
            </Table.Body>
            </Table>
        </>
    )
}

export default InterestTypeView