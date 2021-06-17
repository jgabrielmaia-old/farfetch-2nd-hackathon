import { StyleSheet} from 'react-native';

const styles = StyleSheet.create({
    view: {
        height: 500,
        alignItems: 'center',
        justifyContent: 'center',
    },  
    image: {
        flex: 1,
        resizeMode: "stretch",
        justifyContent: "center",
    },
    text: {
        color: "white",
        fontSize: 42,
        fontWeight: "bold",
        textAlign: "center",
        backgroundColor: "#000000a0"
    }
})

export default styles;