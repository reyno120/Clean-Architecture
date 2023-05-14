import React, { useState } from 'react'
import { Card, CardBody, CardTitle, CardText, Button } from 'reactstrap';
import { Modal, ModalHeader, ModalBody } from 'reactstrap';

export default function RecipeCard(props) {
    const [modal, setModal] = useState(false);

    const toggle = () => setModal(!modal);

    const directions = props.recipe.directions.map(direction =>
        <CardText key={direction.id}>
            {direction.stepNumber}. {direction.description}
        </CardText>) 

    return (
        <Card
            style={{
                width: '18rem'
            }}
        >
            <img
                alt="Sample"
                src="https://picsum.photos/300/200"
            />
            <CardBody>
                <CardTitle tag="h5">
                    {props.recipe.name}
                </CardTitle>
                <CardText>
                    { props.recipe.description }
                </CardText>
                <Button onClick={toggle} color="primary">
                    Directions
                </Button>
            </CardBody>
            <Modal isOpen={modal} toggle={toggle} {...props}>
                <ModalHeader toggle={toggle}>
                    Directions for <strong>{props.recipe.name}</strong>
                </ModalHeader>
                <ModalBody>
                    { directions }
                </ModalBody>
            </Modal>
        </Card>
    );
}